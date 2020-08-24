using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HelloWorldClient
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

    public class Token
    {
        [JsonProperty("token")]
        public string TokenString { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55152/api/"); // Do not forget the trailing backslash.

            var tokenResult = client.GetAsync("token?userName=dave&password=pass").Result;
            var tokenjson = tokenResult.Content.ReadAsStringAsync().Result;

            var token = JsonConvert.DeserializeObject<Token>(tokenjson);

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            // OR
            //var authHeader = new AuthenticationHeaderValue("Bearer", token.TokenString);
            //client.DefaultRequestHeaders.Authorization = authHeader;

            var newContact = new Contact
            {
                Name = "New Name",
                Phones = new[] {
                    new Phone {
                        Number = "425-111-2222",
                        PhoneType = PhoneType.Mobile
                    }
                }
            };

            var newJson = JsonConvert.SerializeObject(newContact);
            var postContent = new StringContent(newJson, System.Text.Encoding.UTF8, "application/json");
            var postResult = client.PostAsync("contacts", postContent).Result;

            Console.WriteLine(postResult.StatusCode);

            var result = client.GetAsync("contacts").Result;

            // Get the content of the result and read the string.
            var json = result.Content.ReadAsStringAsync().Result;

            var list = JsonConvert.DeserializeObject<List<Contact>>(json);

            var id = list[0].Id;
            var deleteResult = client.DeleteAsync("contacts/" + id);

            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}