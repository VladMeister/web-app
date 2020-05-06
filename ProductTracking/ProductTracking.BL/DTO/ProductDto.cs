using ProductTracking.DAL.Entities;
using System;

namespace ProductTracking.BL.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Calority { get; set; }
        public double Price { get; set; }
        public string ProductType { get; set; }
        public DateTime CreationDate { get; set; }

        public string CompanyName { get; set; }
        public string RealizationPlaceName { get; set; }
    }
}
