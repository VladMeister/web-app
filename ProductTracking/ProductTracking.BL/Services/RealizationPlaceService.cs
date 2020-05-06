using AutoMapper;
using ProductTracking.BL.DTO;
using ProductTracking.BL.Services.Interfaces;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.UnitOfWork;
using System.Collections.Generic;

namespace ProductTracking.BL.Services
{
    public class RealizationPlaceService : IRealizationPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RealizationPlaceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddRealizationPlace(RealizationPlaceDto placeDto)
        {
            var place = _mapper.Map<RealizationPlaceDto, RealizationPlace>(placeDto);

            _unitOfWork.RealizationPlaceRepository.Add(place);
            _unitOfWork.Save();
        }

        public IEnumerable<RealizationPlaceDto> GetAllRealizationPlaces()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RealizationPlace, RealizationPlaceDto>()
                .ForMember(r => r.CityId, opt => opt.MapFrom(src => src.City.Id));
            }).CreateMapper();

            var placesDto = _mapper.Map<IEnumerable<RealizationPlace>, IEnumerable<RealizationPlaceDto>>(_unitOfWork.RealizationPlaceRepository.GetAll());

            return placesDto;
        }

        public void DeleteRealizationPlace(RealizationPlaceDto placeDto)
        {
            var place = _mapper.Map<RealizationPlaceDto, RealizationPlace>(placeDto);

            _unitOfWork.RealizationPlaceRepository.Delete(place);
            _unitOfWork.Save();
        }

        public void UpdateRealizationPlace(RealizationPlaceDto placeDto)
        {
            var place = _mapper.Map<RealizationPlaceDto, RealizationPlace>(placeDto);

            _unitOfWork.RealizationPlaceRepository.Update(place);
            _unitOfWork.Save();
        }
    }
}
