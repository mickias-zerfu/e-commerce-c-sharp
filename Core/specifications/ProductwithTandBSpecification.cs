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
        public ProductwithTandBSpecification(string sort)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);

            if(!string.IsNullOrEmpty(sort)){
                switch(sort){                    
                        case ("priceAsc"):
                            AddOrderBy(x=>x.Price);
                            break;
                        case("priceDesc"):
                            AddOrderByDescending(x=>x.Price);
                            break;
                        default:
                            AddOrderBy(n=> n.Name);
                            break;
                }
            }
        }

        public ProductwithTandBSpecification(int id ) : base (x =>x.Id == id )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}