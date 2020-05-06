using ProductTracking.DAL.Repositories.Interfaces;

namespace ProductTracking.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IProductRepository ProductRepository { get; }
        IRealizationPlaceRepository RealizationPlaceRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }

        void Dispose();
        void Save();
    }
}