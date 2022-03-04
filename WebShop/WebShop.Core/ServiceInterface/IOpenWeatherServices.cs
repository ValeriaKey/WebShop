using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Dtos.OpenWeather;

namespace WebShop.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        WeatherResponse GetForecast(string city);
    }
}
