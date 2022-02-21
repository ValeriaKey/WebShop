using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Dtos.Weather;

namespace WebShop.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
