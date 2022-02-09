using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class DegreeDaySummaryDto
    {
        public HeatingDto Heating { get; set; }
        public CoolingDto Cooling { get; set; }
    }
}
