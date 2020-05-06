using System;
using System.ComponentModel.DataAnnotations;

namespace ProductTracking.MVC.Models
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Calority is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public double Calority { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }
}
