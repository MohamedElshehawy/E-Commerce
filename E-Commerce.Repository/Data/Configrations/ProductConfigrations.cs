using E_Commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data.Configrations
{
    internal class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(Product => Product.ProductBrand).WithMany()
                .HasForeignKey(Product => Product.BrandId);

            builder.HasOne(Product => Product.productType).WithMany()
                .HasForeignKey(Product => Product.TypeId);

        }
    }
}
