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

        public ProductwithTandBSpecification(Expression<Func<Product, bool>> criteria, 
            List<Expression<Func<Product, object>>> includes) : base(criteria, includes)
        {
        }
    }
}