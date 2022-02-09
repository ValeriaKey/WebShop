﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class DailyForecastDto
    {
        public string Date { get; set; }
        public int EpochDate { get; set; }
        public SunDto Sun { get; set; }
        public MoonDto Moon { get; set; }
        public TemperatureDto Temperature { get; set; }
        public RealFeelTemperatureDto RealFeelTemperature { get; set; }
        public RealFeelTemperatureShadeDto RealFeelTemperatureShade { get; set; }
        public float HoursOfSun { get; set; }
        public DegreeDaySummaryDto DegreeDaySummary { get; set; }
        public AirAndPollenDto AirAndPollen { get; set; }
        public DayDto Day { get; set; }
        public NightDto Night { get; set; }
    }
}
