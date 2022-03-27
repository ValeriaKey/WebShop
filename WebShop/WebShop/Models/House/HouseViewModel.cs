using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.House
{
    public class HouseViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public int Floors { get; set; }
        public int Rooms { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public DateTime ConstructedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
