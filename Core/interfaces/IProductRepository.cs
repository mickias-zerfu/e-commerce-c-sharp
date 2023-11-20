using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Product>> GetProductsAsync();

        // Brands
        Task<ProductBrand> GetProductBrandByIdAsync(int id);

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        // Types
        Task<ProductType> GetProductTypeByIdAsync(int id);

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}