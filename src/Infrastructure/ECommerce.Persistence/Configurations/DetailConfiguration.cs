using Bogus;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new Faker("en");

            builder.HasData(new Detail()
            {
                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Detail()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(3),
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = true
            },
            new Detail()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
