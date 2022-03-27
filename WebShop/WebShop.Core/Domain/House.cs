using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Domain
{
    public class House
    {
        [Key]
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public int Floors { get; set; }
        public int Rooms { get; set; }
        public double Price { get; set; }
        public double Area { get; set; }
        public string Color { get; set; }
        public DateTime ConstructedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
