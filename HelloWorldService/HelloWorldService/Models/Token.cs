using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldService.Models
{
    public class Token
    {
        [JsonProperty("token")]
        public string TokenString { get; set; }
    }
}
