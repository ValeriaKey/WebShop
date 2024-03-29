﻿using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
            {
               // string apikey = "Vh7XvBuQV8AKMFw6wyQLeEgBMxa9GmHd";
                var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=Vh7XvBuQV8AKMFw6wyQLeEgBMxa9GmHd&metric=true";

                using (WebClient client = new())
                {
                    string json = client.DownloadString(url);
                    //ainult ühe classi saab deserialiseerida
                    WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                    dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                    dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                    dto.Severity = weatherInfo.Headline.Severity;
                    dto.Text = weatherInfo.Headline.Text;
                    dto.Category = weatherInfo.Headline.Category;
                    dto.EndDate = weatherInfo.Headline.EndDate;
                    dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;

                    dto.MobileLink = weatherInfo.Headline.MobileLink;
                    dto.Link = weatherInfo.Headline.Link;

                    dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                    dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                    dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                    dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                    dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                    dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                    dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                    dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                    dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;

                    dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                    dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                    dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;

                    var jsonString = new JavaScriptSerializer().Serialize(dto);
                }
                return dto;
            }

            
        }
    }