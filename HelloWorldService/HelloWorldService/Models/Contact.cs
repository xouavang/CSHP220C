using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloWorldService.Models
{
    public class Contact
    {
        // [JsonProperty("Id")] Allows REST service to respect casing in .net core.
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("date_Added")]
        public DateTime DateAdded { get; set; }
        public Phone[] Phones { get; set; }
    }

    // Create a new Contact Version, instead of modifying exisiting Contact, to ensure it does not break client code.
    // ContactV2 is not used in HellowWorldService. Just demonstrating Versioning.
    public class ContactV2
    {
        // [JsonProperty("Id")] Allows REST service to respect casing in .net core.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonProperty("date_Added")]
        public DateTime DateAdded { get; set; }
        public Phone[] Phones { get; set; }
    }

    public class Phone
    {
        [JsonProperty("number", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Number { get; set; }

        // Needs JsonConverter or else will return an integer.
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("phone_Type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Nil,
        Home,
        Mobile,
    }
}
