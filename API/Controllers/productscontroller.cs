using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly StoreContext _Context;
        public ProductsController(StoreContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var products = _Context.Products.ToListAsync();
            return  Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            return await _Context.Products.FindAsync(id);
        }
    }
}