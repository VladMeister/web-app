using Microsoft.EntityFrameworkCore;
using ProductTracking.DAL.EF;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProductTracking.DAL.Repositories
{
    public class RealizationPlaceRepository : IRealizationPlaceRepository
    {
        private readonly ProductTrackingContext _trackingContext;

        public RealizationPlaceRepository(ProductTrackingContext dbContext)
        {
            _trackingContext = dbContext;
        }

        public void Add(RealizationPlace realizationPlace)
        {
            _trackingContext.RealizationPlaces.Add(realizationPlace);
        }

        public IEnumerable<RealizationPlace> GetAll()
        {
            if (_trackingContext.RealizationPlaces.Include(r => r.City).Count() != 0)
            {
                return _trackingContext.RealizationPlaces.Include(r => r.City).AsNoTracking().ToList();
            }

            return Enumerable.Empty<RealizationPlace>();
        }

        public void Update(RealizationPlace realizationPlace)
        {
            if (realizationPlace != null)
            {
                _trackingContext.Entry(realizationPlace).State = EntityState.Modified;
            }
        }

        public void Delete(RealizationPlace realizationPlace)
        {
            var placeToDelete = _trackingContext.RealizationPlaces.FirstOrDefault(r => r.Id == realizationPlace.Id);

            if (placeToDelete != null)
            {
                _trackingContext.RealizationPlaces.Remove(placeToDelete);
            }
        }

        public bool ExistingPlace(string name)
        {
            var exists = _trackingContext.RealizationPlaces.Any(r => r.Name == name);

            return exists;
        }

        public RealizationPlace GetRealizationPlaceByName(string name)
        {
            return _trackingContext.RealizationPlaces.FirstOrDefault(r => r.Name == name);
        }
    }
}
