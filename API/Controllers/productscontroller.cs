using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepostiory<Product> _productRepository;

        private readonly IGenericRepostiory<ProductBrand> _productBrandRepository;
        private readonly IGenericRepostiory<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepostiory<Product> productRepository,
        IGenericRepostiory<ProductBrand> productBrandRepository,
        IGenericRepostiory<ProductType> productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
            _productBrandRepository = productBrandRepository;
            _productRepository = productRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> getProducts()
        {
            var spec = new ProductwithTandBSpecification();
            var products = await _productRepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
            
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> getProductBrands()
        {
            var productBrands = await _productBrandRepository.GetProductsAsync();
            return Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<Product>>> getProductTypes()
        {
            var productTypes = await _productTypeRepository.GetProductsAsync();
            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> getProduct(int id)
        {

            var spec = new ProductwithTandBSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
        // [HttpGet("types{id}")]
        // public async Task<ActionResult<ProductType>> getProductType(int id)
        // {
        //     return await _productRepository.GetProductTypeByIdAsync(id);
        // }
        // [HttpGet("brands/{id}")]
        // public async Task<ActionResult<ProductBrand>> getProductBrand(int id)
        // {
        //     return await _productRepository.GetProductBrandByIdAsync(id);
        // }
    }
}