using Microsoft.EntityFrameworkCore;
using ProductTracking.DAL.EF;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProductTracking.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductTrackingContext _trackingContext;

        public ProductRepository(ProductTrackingContext dbContext)
        {
            _trackingContext = dbContext;
        }

        public void Add(Product product)
        {
            _trackingContext.Products.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            if (_trackingContext.Products.Include(p => p.Company).Count() != 0)
            {
                return _trackingContext.Products.Include(p => p.Company).AsNoTracking().ToList();
            }

            return Enumerable.Empty<Product>();
        }

        public void Update(Product product)
        {
            var productToUpdate = _trackingContext.Products.FirstOrDefault(p => p.Id == product.Id);

            productToUpdate.Name = product.Name;
            productToUpdate.Weight = product.Weight;
            productToUpdate.Calority = product.Calority;
            productToUpdate.Price = product.Price;

            if (productToUpdate != null)
            {
                _trackingContext.Entry(productToUpdate).State = EntityState.Modified;
            }
        }

        public void Delete(Product product)
        {
            var productToDelete = _trackingContext.Products.FirstOrDefault(p => p.Id == product.Id);

            if (productToDelete != null)
            {
                _trackingContext.Products.Remove(productToDelete);
            }
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _trackingContext.Products.Where(p => p.Name == name);
        }

        public Product GetById(int? id)
        {
            return _trackingContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
