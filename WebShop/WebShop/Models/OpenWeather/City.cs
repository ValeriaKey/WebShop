﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.OpenWeather
{
    public class City
    {
        [Display(Name = "City:")]
        public string Name { get; set; }

        [Display(Name = "Temperature:")]
        public float Temp { get; set; }

        [Display(Name = "Temp Feels like:")]
        public float Feels_Like { get; set; }

        [Display(Name = "Humidity")]
        public int Humidity { get; set; }

        [Display(Name = "Pressure:")]
        public int Pressure { get; set; }

        [Display(Name = "Wind Speed:")]
        public float Wind { get; set; }

        [Display(Name = "Weather Condition:")]
        public string Weather { get; set; }
    }
}
