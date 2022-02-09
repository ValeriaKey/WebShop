using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Dtos;
using WebShop.Core.Dtos.Weather;
using WebShop.Core.ServiceInterface;

namespace WebShop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public string WeatherResponse(string city)
        {
            string idWeather = "Vh7XvBuQV8AKMFw6wyQLeEgBMxa9GmHd";
            var Location = "asd";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{Location}?apikey={idWeather}";
            // var client1 = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=Vh7XvBuQV8AKMFw6wyQLeEgBMxa9GmHd");
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                DailyForecastDto weatherInfo = (new JavaScriptSerializer()).Deserialize<DailyForecastDto>(json);
                HeadlineDto headlineInfo = (new JavaScriptSerializer()).Deserialize<HeadlineDto>(json);

                WeatherResultDto result = new WeatherResultDto();

                result.EffectiveDate = headlineInfo.EffectiveDate;
                result.EffectiveEpochDate = headlineInfo.EffectiveEpochDate;
                result.Severity = headlineInfo.Severity;
                result.Text = headlineInfo.Text;
                result.Category = headlineInfo.Category;
                result.EndDate = headlineInfo.EndDate;
                result.EndEpochDate = headlineInfo.EndEpochDate;
                result.MobileLink = headlineInfo.MobileLink;
                result.Link = headlineInfo.Link;
                result.Date = weatherInfo.Date;
                result.EpochDate = weatherInfo.EpochDate;

                result.TempMinValue = weatherInfo.Temperature.Minimum.Value;
                result.TempMinUnit = weatherInfo.Temperature.Minimum.Unit;
                result.TempMinUnitType = weatherInfo.Temperature.Minimum.UnitType;

                result.TempMaxValue = weatherInfo.Temperature.Maximum.Value;
                result.TempMaxUnit = weatherInfo.Temperature.Maximum.Unit;
                result.TempMaxUnitType = weatherInfo.Temperature.Maximum.UnitType;

                result.DayIcon = weatherInfo.Day.Icon;
                result.DayIconPhrase = weatherInfo.Day.IconPhrase;
                result.DayHasPrecipitation = weatherInfo.Day.HasPrecipitation;
                result.DayPrecipitationType = weatherInfo.Day.PrecipitationType;
                result.DayPrecipitationIntensity = weatherInfo.Day.PrecipitationIntensity;

                result.NightIcon = weatherInfo.Night.Icon;
                result.NightIconPhrase = weatherInfo.Night.IconPhrase;
                result.NightHasPrecipitation = weatherInfo.Night.HasPrecipitation;
                result.NightPrecipitationType = weatherInfo.Night.PrecipitationType;
                result.NightPrecipitationIntensity = weatherInfo.Night.PrecipitationIntensity;

                var jsonString = new JavaScriptSerializer().Serialize(result);

                return jsonString;
            }
        }
    }
}
