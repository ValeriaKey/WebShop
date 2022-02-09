using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class WindDto
    {
        public SpeedDto Speed { get; set; }
        public DirectionDto Direction { get; set; }
    }
}
