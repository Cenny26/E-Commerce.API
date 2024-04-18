using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category()
            {
                Id = Guid.Parse("090F32DF-66C3-46F1-92BC-43E4111BFE49"),
                Name = "Electronic",
                Priority = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category()
            {
                Id = Guid.Parse("0CDBEF26-5970-4859-9D7C-4A4FFB1CF6B7"),
                Name = "Fashion",
                Priority = 2,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category()
            {
                Id = Guid.Parse("94D99305-797E-4FA5-882F-88A5A4806ACD"),
                ParentId = Guid.Parse("090F32DF-66C3-46F1-92BC-43E4111BFE49"),
                Name = "Computer",
                Priority = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category()
            {
                Id = Guid.Parse("B3D66B61-F1F5-4C13-8018-372999BBFF4F"),
                ParentId = Guid.Parse("0CDBEF26-5970-4859-9D7C-4A4FFB1CF6B7"),
                Name = "Shoes",
                Priority = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
