using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Files;

namespace WebShop.Models.Car
{
    public class CarListViewModel
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Moodel { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ExistingFilePathForCarViewModel> ExistingFilePathsForCar { get; set; } = new List<ExistingFilePathForCarViewModel>();
    }
}
