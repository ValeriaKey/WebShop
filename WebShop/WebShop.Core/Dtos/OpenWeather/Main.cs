using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.OpenWeather
{
    public class  Main
    {
        public float Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public float Temp_Min { get; set; }
        public float Feels_Like { get; set; }
        public float Temp_Max { get; set; }
    }
}
