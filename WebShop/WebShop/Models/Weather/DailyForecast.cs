﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Weather
{
    public class DailyForecast
    {
        public string Date { get; set; }
        public int EpochDate { get; set; }
        public Sun Sun { get; set; }
        public Moon Moon { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
        public float HoursOfSun { get; set; }
        public DegreeDaySummary DegreeDaySummary { get; set; }
        public AirAndPollen AirAndPollen { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
    }
}
