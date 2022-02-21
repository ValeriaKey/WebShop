using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebShop.Models.Weather
{
    public class DegreeDaySummary
    {
        public Heating Heating { get; set; }
        public Cooling Cooling { get; set; }
    }
}
