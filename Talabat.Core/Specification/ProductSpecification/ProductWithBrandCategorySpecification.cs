using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.Specification.ProductSpecification
{
    public class ProductWithBrandCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithBrandCategorySpecification() : base() 
        {
            includes.Add(P => P.Brand);
            includes.Add(P => P.Category);
        }
        public ProductWithBrandCategorySpecification(int id) : base(P=>P.Id == id)
        {
            includes.Add(P => P.Brand);
            includes.Add(P => P.Category);
        }
    }
}
