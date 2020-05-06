using System.Collections.Generic;

namespace ProductTracking.DAL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool Registered { get; set; }
        public ICollection<Product> Products { get; set; }

        public Company()
        {
            Products = new List<Product>();
        }
    }
}
