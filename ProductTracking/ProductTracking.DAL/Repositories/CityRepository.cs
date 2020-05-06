using Microsoft.EntityFrameworkCore;
using ProductTracking.DAL.EF;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProductTracking.DAL.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ProductTrackingContext _trackingContext;

        public CityRepository(ProductTrackingContext dbContext)
        {
            _trackingContext = dbContext;
        }

        public void Add(City city)
        {
            _trackingContext.Cities.Add(city);
        }

        public IEnumerable<City> GetAll()
        {
            if (_trackingContext.Cities.Count() != 0)
            {
                return _trackingContext.Cities.AsNoTracking().ToList();
            }

            return Enumerable.Empty<City>();
        }

        public void Update(City city)
        {
            if (city != null)
            {
                _trackingContext.Entry(city).State = EntityState.Modified;
            }
        }

        public void Delete(City city)
        {
            var cityToDelete = _trackingContext.Cities.FirstOrDefault(c => c.Id == city.Id);

            if (cityToDelete != null)
            {
                _trackingContext.Cities.Remove(cityToDelete);
            }
        }

        public City GetCityByRealizationPlace(string placeName)
        {
            foreach(var city in _trackingContext.Cities)
            {
                foreach(var place in city.RealizationPlaces)
                {
                    if(place.Name == placeName)
                    {
                        return city;
                    }
                }
            }

            return null;
        }
    }
}
