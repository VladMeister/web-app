using AutoMapper;
using ProductTracking.BL.DTO;
using ProductTracking.BL.Services.Interfaces;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.UnitOfWork;
using System;
using System.Collections.Generic;

namespace ProductTracking.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddProduct(ProductDto productDto)
        {
            if (_unitOfWork.CompanyRepository.ExistingCompany(productDto.CompanyName) 
                && _unitOfWork.RealizationPlaceRepository.ExistingPlace(productDto.RealizationPlaceName))
            {
                var product = new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Weight = productDto.Weight,
                    Calority = productDto.Calority,
                    CreationDate = productDto.CreationDate,
                    Price = productDto.Price,
                    Company = _unitOfWork.CompanyRepository.GetCompanyByName(productDto.CompanyName),
                    RealizationPlace = _unitOfWork.RealizationPlaceRepository.GetRealizationPlaceByName(productDto.RealizationPlaceName)
                };

                //var city = _unitOfWork.CityRepository.GetCityByRealizationPlace(productDto.RealizationPlaceName);

                try
                {
                    var productType = (ProductType)Enum.Parse(typeof(ProductType), productDto.ProductType);
                }
                catch (Exception)
                {
                    product.ProductType = ProductType.Uncategorized;
                }

                _unitOfWork.ProductRepository.Add(product);
                _unitOfWork.Save();

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>()
                .ForMember(p => p.CompanyName, opt => opt.MapFrom(src => src.Company.Id));
            }).CreateMapper();

            var productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_unitOfWork.ProductRepository.GetAll());

            return productsDto;
        }

        public void DeleteProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);

            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.Save();
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);

            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Save();
        }

        public IEnumerable<ProductDto> GetProductsByName(string name)
        {
            var products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_unitOfWork.ProductRepository.GetByName(name));

            return products;
        }

        public ProductDto GetProductById(int? id)
        {
            var product = _mapper.Map<Product, ProductDto>(_unitOfWork.ProductRepository.GetById(id));

            return product;
        }
    }
}
