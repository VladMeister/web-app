
using System.Collections.Generic;

namespace ProductTracking.DAL.Entities
{
    public class RealizationPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkTime { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public ICollection<Product> Products { get; set; }

        public RealizationPlace()
        {
            Products = new List<Product>();
        }
    }
}
