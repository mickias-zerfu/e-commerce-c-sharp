using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.specifications
{
    public class ProductwithTandBSpecification : BaseSpecification<Product>
    {
        public ProductwithTandBSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }

        public ProductwithTandBSpecification(int id ) : base (x =>x.Id == id )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}