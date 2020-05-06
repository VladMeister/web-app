using ProductTracking.BL.DTO;
using System.Collections.Generic;

namespace ProductTracking.BL.Services.Interfaces
{
    public interface IRealizationPlaceService
    {
        void AddRealizationPlace(RealizationPlaceDto placeDto);
        void DeleteRealizationPlace(RealizationPlaceDto placeDto);
        IEnumerable<RealizationPlaceDto> GetAllRealizationPlaces();
        void UpdateRealizationPlace(RealizationPlaceDto placeDto);
    }
}