using E_Commerce.Core.Entities;
using E_Commerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product>
    {
        // Get Products With Filteration
        // brandId & typeId 
        public ProductSpecifications(ProductSpecificationparameters specs ) 
            : base(Product =>
            (!specs.TypeId.HasValue || Product.Id==specs.TypeId.Value) && 
            (!specs.BrandId.HasValue || Product.Id == specs.BrandId.Value) &&
            (string.IsNullOrWhiteSpace(specs.Search) || Product.Name.ToLower().Contains(specs.Search)))
        {
            IncludExpressions.Add(Product => Product.ProductBrand);
            IncludExpressions.Add(Product => Product.productType);

            ApplyPagination(specs.PageSize,specs.PageIndex);

            if (specs.Sort is not null)
            {
                switch (specs.Sort)
                {
                    case ProductSortingParamters.NameAsc: 
                           OrderBy = x => x.Name;
                        break;
                    case ProductSortingParamters.NameDesc: 
                           OrderByDesc = x => x.Name;
                        break;
                    case ProductSortingParamters.PriceAsc:
                        OrderBy = x => x.Price;
                        break;
                    case ProductSortingParamters.PriceDesc:
                        OrderByDesc = x => x.Price;
                        break;
                    default:
                        OrderBy = x => x.Name;
                        break;
                }

            }
            else
            {
                OrderBy = x => x.Name;

            }
        } 
        // Get Product BY ID
        public ProductSpecifications(int id) : base(Product => Product.Id==id)
        {
            IncludExpressions.Add(Product => Product.ProductBrand);
            IncludExpressions.Add(Product => Product.productType);
        }

    }
}
