using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Domain
{
    public class ExistingFilePathForCar
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}
