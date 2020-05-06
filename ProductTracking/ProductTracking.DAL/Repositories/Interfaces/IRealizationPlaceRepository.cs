using ProductTracking.DAL.Entities;
using System.Collections.Generic;

namespace ProductTracking.DAL.Repositories.Interfaces
{
    public interface IRealizationPlaceRepository
    {
        void Add(RealizationPlace realizationPlace);
        void Delete(RealizationPlace realizationPlace);
        bool ExistingPlace(string name);
        IEnumerable<RealizationPlace> GetAll();
        RealizationPlace GetRealizationPlaceByName(string name);
        void Update(RealizationPlace realizationPlace);
    }
}