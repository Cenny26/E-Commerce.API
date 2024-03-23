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
                Id = 1,
                ParentId = 0,
                Name = "Electronic",
                Priority = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category()
            {
                Id = 2,
                ParentId = 0,
                Name = "Fashion",
                Priority = 2,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category()
            {
                Id = 3,
                ParentId = 1,
                Name = "Computer",
                Priority = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category()
            {
                Id = 4,
                ParentId = 2,
                Name = "Woman",
                Priority = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
