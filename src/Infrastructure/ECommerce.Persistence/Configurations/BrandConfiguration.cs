using Bogus;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            Faker faker = new Faker(locale: "en");

            builder.HasData(new Brand()
            {
                Id = 1,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand()
            {
                Id = 2,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand()
            {
                Id = 3,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = true
            });
        }
    }
}
