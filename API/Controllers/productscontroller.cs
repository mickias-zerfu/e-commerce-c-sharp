using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    { 
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        { 
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return  Ok(products);
        }
        
        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> getProductBrands()
        {
            var productBrands = await _productRepository.GetProductBrandsAsync();
            return  Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<Product>>> getProductTypes()
        {
            var productTypes = await _productRepository.GetProductTypesAsync();
            return  Ok(productTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            return await _productRepository
            .GetProductByIdAsync(id);
        }
        [HttpGet("types{id}")]
        public async Task<ActionResult<ProductType>> getProductType(int id)
        {
            return await _productRepository.GetProductTypeByIdAsync(id);
        }
        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> getProductBrand(int id)
        {
            return await _productRepository.GetProductBrandByIdAsync(id);
        }
    }
}