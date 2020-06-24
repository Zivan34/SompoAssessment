using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.SompoAPI
{
    public class Response
    {
        public partial class PolicyStatusResults
        {
            [JsonProperty("Results")]
            public Result[] Results { get; set; }
        }

        public partial class Result
        {
            [JsonProperty("Code")]
            public string Code { get; set; }

            [JsonProperty("Description")]
            public string Description { get; set; }

            [JsonProperty("Status")]
            public Status Status { get; set; }
        }

        public partial class Status
        {
            [JsonProperty("Value")]
            public string Value { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }
        }
    }
}
