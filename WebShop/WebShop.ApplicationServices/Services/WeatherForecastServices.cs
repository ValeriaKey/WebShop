using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Dtos;

namespace WebShop.ApplicationServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<WeatherDto> WeatherResponse()
        {
            string idWeather = "Vh7XvBuQV8AKMFw6wyQLeEgBMxa9GmHd";
            var Location = "asd";
            var client = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{Location}?apikey={idWeather}");
            var client1 = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=Vh7XvBuQV8AKMFw6wyQLeEgBMxa9GmHd");

            return null;
        }
    }
}
