using Microsoft.EntityFrameworkCore;
using ProductTracking.DAL.EF;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProductTracking.DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ProductTrackingContext _trackingContext;

        public CompanyRepository(ProductTrackingContext dbContext)
        {
            _trackingContext = dbContext;
        }

        public void Add(Company company)
        {
            _trackingContext.Companies.Add(company);
        }

        public IEnumerable<Company> GetAll()
        {
            if (_trackingContext.Companies.Count() != 0)
            {
                return _trackingContext.Companies.AsNoTracking().ToList();
            }

            return Enumerable.Empty<Company>();
        }

        public void Update(Company company)
        {
            if (company != null)
            {
                _trackingContext.Entry(company).State = EntityState.Modified;
            }
        }

        public void Delete(Company company)
        {
            var companyToDelete = _trackingContext.Companies.FirstOrDefault(f => f.Id == company.Id);

            if (companyToDelete != null)
            {
                _trackingContext.Companies.Remove(companyToDelete);
            }
        }

        public bool ExistingCompany(string name)
        {
            var exists = _trackingContext.Companies.Any(c => c.Name == name);

            return exists;
        }

        public Company GetCompanyByName(string name)
        {
            return _trackingContext.Companies.FirstOrDefault(c => c.Name == name);
        }
    }
}
