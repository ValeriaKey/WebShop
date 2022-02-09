using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class DirectionDto
    {
        public double Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }
}
