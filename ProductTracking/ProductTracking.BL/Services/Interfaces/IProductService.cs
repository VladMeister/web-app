using ProductTracking.BL.DTO;
using System.Collections.Generic;

namespace ProductTracking.BL.Services.Interfaces
{
    public interface IProductService
    {
        bool AddProduct(ProductDto productDto);
        void DeleteProduct(ProductDto productDto);
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int? id);
        IEnumerable<ProductDto> GetProductsByName(string name);
        void UpdateProduct(ProductDto productDto);
    }
}