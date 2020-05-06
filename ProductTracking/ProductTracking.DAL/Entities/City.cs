using System.Collections.Generic;

namespace ProductTracking.DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeliveryWay DeliveryWay { get; set; }
        public IList<RealizationPlace> RealizationPlaces { get; set; }

        public City()
        {
            RealizationPlaces = new List<RealizationPlace>();
        }
    }

    public enum DeliveryWay
    {
        Car,
        Train,
        Plane
    }
}
