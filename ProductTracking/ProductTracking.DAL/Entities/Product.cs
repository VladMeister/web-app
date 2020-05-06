using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ProductTracking.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Calority { get; set; }
        public double Price { get; set; }
        public ProductType ProductType { get; set; }
        public DateTime CreationDate { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? RealizationPlaceId { get; set; }
        public RealizationPlace RealizationPlace { get; set; }

    }

    public enum ProductType
    {
        Meat,
        Milk,
        Cereals,
        Eggs,
        Mushrooms,
        Fruits,
        Vegetables,
        Uncategorized
    }
}
