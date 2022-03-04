using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.OpenWeather
{
    public class WeatherResponse
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
