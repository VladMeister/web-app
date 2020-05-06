using ProductTracking.DAL.Entities;
using System.Collections.Generic;

namespace ProductTracking.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(Product product);
        IEnumerable<Product> GetAll();
        Product GetById(int? id);
        IEnumerable<Product> GetByName(string name);
        void Update(Product product);
    }
}