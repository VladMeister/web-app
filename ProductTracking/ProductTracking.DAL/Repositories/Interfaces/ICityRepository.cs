using ProductTracking.DAL.Entities;
using System.Collections.Generic;

namespace ProductTracking.DAL.Repositories.Interfaces
{
    public interface ICityRepository
    {
        void Add(City city);
        void Delete(City city);
        IEnumerable<City> GetAll();
        City GetCityByRealizationPlace(string placeName);
        void Update(City city);
    }
}