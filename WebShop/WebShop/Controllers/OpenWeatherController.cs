using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.Dtos.OpenWeather;
using WebShop.Core.ServiceInterface;
using WebShop.Models.OpenWeather;

namespace WebShop.Controllers
{
    public class OpenWeatherController : Controller {

        private readonly IOpenWeatherServices _openWeatherServices;

        // Dependency Injection
        public OpenWeatherController(IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }

        // GET: OpenWeatherController

        public IActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        // POST: OpenWeatherController/Create
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeather", new { city = model.CityName });
            }
            return View(model);
        }
        // GET: OpenWeatherController
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _openWeatherServices.GetForecast(city);
            City viewModel = new City();
            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Feels_Like = weatherResponse.Main.Feels_Like;
                viewModel.Temp = weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
            return View(viewModel);
      
        }
    }
}
