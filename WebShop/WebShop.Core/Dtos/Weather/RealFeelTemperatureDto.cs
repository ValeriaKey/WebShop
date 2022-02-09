using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class RealFeelTemperatureDto
    {
        public MinimumDto Minimum { get; set; }
        public MaximumDto Maximum { get; set; }
    }
}
