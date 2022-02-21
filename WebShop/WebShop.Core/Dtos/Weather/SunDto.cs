using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class SunDto
    {
        [JsonProperty("Rise")]
        public string Rise { get; set; }

        [JsonProperty("EpochRise")]
        public Int64 EpochRise { get; set; }

        [JsonProperty("Set")]
        public string Set { get; set; }

        [JsonProperty("EpochSet")]
        public Int64 EpochSet { get; set; }
    }
    }
