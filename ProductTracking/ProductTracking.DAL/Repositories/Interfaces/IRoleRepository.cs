using ProductTracking.DAL.Entities;

namespace ProductTracking.DAL.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Role GetByName(string name);
        string[] GetNames();
    }
}