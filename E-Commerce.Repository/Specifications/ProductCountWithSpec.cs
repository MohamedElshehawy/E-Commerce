using E_Commerce.Core.Entities;
using E_Commerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Specifications
{
    public class ProductCountWithSpec : BaseSpecifications<Product>
    {
        public ProductCountWithSpec(ProductSpecificationparameters specParameters)
        : base(Product =>
        (!specParameters.TypeId.HasValue || Product.Id == specParameters.TypeId.Value) &&
            (!specParameters.BrandId.HasValue || Product.Id == specParameters.BrandId.Value) &&
            (string.IsNullOrWhiteSpace(specParameters.Search) || Product.Name.ToLower().Contains(specParameters.Search)))
        {
        }
    }
}
