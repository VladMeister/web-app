using ProductTracking.DAL.Entities;
using System.Collections.Generic;

namespace ProductTracking.DAL.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        void Add(Company factory);
        void Delete(Company factory);
        bool ExistingCompany(string name);
        IEnumerable<Company> GetAll();
        Company GetCompanyByName(string name);
        void Update(Company factory);
    }
}