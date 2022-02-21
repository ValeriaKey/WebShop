using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class DirectionDto
    {
        [JsonProperty("Degrees")]
        public double Degrees { get; set; }

        [JsonProperty("Localized")]
        public string Localized { get; set; }

        [JsonProperty("English")]
        public string English { get; set; }
    }
}
