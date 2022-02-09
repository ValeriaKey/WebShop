using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.Dtos.Weather;
using WebShop.Core.ServiceInterface;
using WebShop.Models.Weather;

namespace WebShop.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherController
            (
                IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            SearchCity sc = new SearchCity();

            return View(sc);
        }

        [HttpPost]
        public IActionResult City(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult SearchCity(string city)
        {
            var weatherResponse = _weatherForecastServices.WeatherResponse(city);
            WeatherResultViewModel model = new WeatherResultViewModel();
            WeatherResultDto dto = new WeatherResultDto();
            HeadlineDto headlineDto = new HeadlineDto();

            if (weatherResponse != null)
            {

                model.EffectiveDate = headlineDto.EffectiveDate;
                model.EffectiveEpochDate = headlineDto.EffectiveEpochDate;
                model.Severity = headlineDto.Severity;
                model.Text = headlineDto.Text;
                model.Category = headlineDto.Category;
                model.EndDate = headlineDto.EndDate;
                model.EndEpochDate = headlineDto.EndEpochDate;
                model.MobileLink = headlineDto.MobileLink;
                model.Link = headlineDto.Link;

                model.Date = dto.Date;
                model.EpochDate = dto.EpochDate;

                model.TempMinValue = dto.TempMinValue;
                model.TempMinUnit = dto.TempMinUnit;
                model.TempMinUnitType = dto.TempMinUnitType;

                model.TempMaxValue = dto.TempMaxValue;
                model.TempMaxUnit = dto.TempMaxUnit;
                model.TempMaxUnitType = dto.TempMaxUnitType;

                model.DayIcon = dto.DayIcon;
                model.DayIconPhrase = dto.DayIconPhrase;
                model.DayHasPrecipitation = dto.DayHasPrecipitation;
                model.DayPrecipitationType = dto.DayPrecipitationType;
                model.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

                model.NightIcon = dto.NightIcon;
                model.NightIconPhrase = dto.NightIconPhrase;
                model.NightHasPrecipitation = dto.NightHasPrecipitation;
                model.NightPrecipitationType = dto.NightPrecipitationType;
                model.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;
            }

            return View(model);
        }

    }
}
