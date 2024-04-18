using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(new Brand()
            {
                Id = Guid.Parse("BCA0CBC5-1CEA-4444-B613-4E3B4C42FEE0"),
                Name = "Acer",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand()
            {
                Id = Guid.Parse("D772AD17-69CA-442A-AB49-2FCF3E742815"),
                Name = "Apple",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand()
            {
                Id = Guid.Parse("4C9CDADF-C178-439F-866C-517F89810FDF"),
                Name = "Adidas",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
