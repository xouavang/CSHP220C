using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;

namespace HelloWorldService.Tests
{
    public class Contact
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("phones")]
        public Phone[] Phones { get; set; }
    }

    public class Phone
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("phone_type")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Home,
        Mobile,
    }

    public class Tests
    {
        HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55152/api/");
        }

        [Test]
        public void TestAddNewContact()
        {
            var postResult = CreateContact("AddNewContactTest");

            Assert.AreEqual(HttpStatusCode.Created, postResult.StatusCode);

            postResult.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void TestGetAll()
        {
            var result = client.GetAsync("contacts").Result;

            //Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void TestGetSpecific_Good()
        {
            var postResult = CreateContact("TestGetSpecific_Good");
            var json = postResult.Content.ReadAsStringAsync().Result;

            var contact = JsonConvert.DeserializeObject<Contact>(json);
            var result = client.GetAsync("contacts/" + contact.Id).Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void TestGetSpecific_Bad()
        {
            var result = client.GetAsync("contacts/10211").Result;

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public void TestDelete_ValidContact()
        {
            var postResult = CreateContact("TestDeleteContact");
            var json = postResult.Content.ReadAsStringAsync().Result;

            var contact = JsonConvert.DeserializeObject<Contact>(json);
            
            var result = client.DeleteAsync("contacts/" + contact.Id).Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void TestDelete_InvalidContactId()
        {
            var result = client.DeleteAsync("contacts/1").Result;

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage CreateContact(string name)
        {
            var newContact = new Contact
            {
                Name = name,
                Phones = new[] {
                    new Phone {
                        Number = "425-111-2222",
                        PhoneType = PhoneType.Mobile
                    }
                }
            };
            var newJson = JsonConvert.SerializeObject(newContact);
            var postContent = new StringContent(newJson, Encoding.UTF8, "application/json");
            var postResult = client.PostAsync("contacts", postContent).Result;

            return postResult;
        }
    }
}