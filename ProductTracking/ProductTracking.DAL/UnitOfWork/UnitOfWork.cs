using ProductTracking.DAL.EF;
using ProductTracking.DAL.Repositories.Interfaces;
using System;

namespace ProductTracking.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICityRepository CityRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public IRealizationPlaceRepository RealizationPlaceRepository { get; }
        public IRoleRepository RoleRepository { get; }

        private readonly ProductTrackingContext _trackingContext;

        private bool _disposed = false;

        public UnitOfWork(ProductTrackingContext dbContext, IUserRepository userRepository, IProductRepository productRepository, ICityRepository cityRepository, ICompanyRepository companyRepository, IRealizationPlaceRepository realizationPlaceRepository, IRoleRepository roleRepository)
        {
            _trackingContext = dbContext;
            UserRepository = userRepository;
            ProductRepository = productRepository;
            CityRepository = cityRepository;
            CompanyRepository = companyRepository;
            RealizationPlaceRepository = realizationPlaceRepository;
            RoleRepository = roleRepository;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _trackingContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _trackingContext.SaveChanges();
        }
    }
}
