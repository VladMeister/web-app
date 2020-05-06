using ProductTracking.DAL.EF;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.Repositories.Interfaces;
using System.Linq;

namespace ProductTracking.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ProductTrackingContext _trackingContext;

        public RoleRepository(ProductTrackingContext dbContext)
        {
            _trackingContext = dbContext;
        }

        public string[] GetNames()
        {
            return _trackingContext.Roles.Select(r => r.Name).ToArray();
        }

        public Role GetByName(string name)
        {
            return _trackingContext.Roles.FirstOrDefault(r => r.Name == name);
        }
    }
}
