using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new ProductCategory()
            {
                ProductId = Guid.Parse("9B710AC8-A0F1-428D-A1B3-66FFA49890B8"),
                CategoryId = Guid.Parse("090F32DF-66C3-46F1-92BC-43E4111BFE49")
            },
            new ProductCategory()
            {
                ProductId = Guid.Parse("9B710AC8-A0F1-428D-A1B3-66FFA49890B8"),
                CategoryId = Guid.Parse("94D99305-797E-4FA5-882F-88A5A4806ACD")
            },
            new ProductCategory()
            {
                ProductId = Guid.Parse("D750BE8A-97B3-48C1-A72D-AC55C880935B"),
                CategoryId = Guid.Parse("0CDBEF26-5970-4859-9D7C-4A4FFB1CF6B7")
            },
            new ProductCategory()
            {
                ProductId = Guid.Parse("D750BE8A-97B3-48C1-A72D-AC55C880935B"),
                CategoryId = Guid.Parse("B3D66B61-F1F5-4C13-8018-372999BBFF4F")
            });
        }
    }
}
