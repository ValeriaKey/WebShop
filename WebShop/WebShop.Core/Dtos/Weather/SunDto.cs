using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos.Weather
{
    public class SunDto
    {
        public string Rise { get; set; }
        public int EpochRise { get; set; }
        public string Set { get; set; }
        public int EpochSet { get; set; }
    }
}
