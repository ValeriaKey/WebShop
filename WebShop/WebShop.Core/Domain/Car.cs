using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Domain
{
    public class Car
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Moodel { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IEnumerable<ExistingFilePathForCar> ExistingFilePathsForCar { get; set; } = new List<ExistingFilePathForCar>();
    }
}
