using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product()
            {
                Id = Guid.Parse("9B710AC8-A0F1-428D-A1B3-66FFA49890B8"),
                Title = "Acer Nitro V 15",
                Description = "Elevate your gaming adventure with the Acer Nitro V 15, your gateway to an adrenaline-charged journey. This laptop is the perfect blend of power and style, pushing the boundaries of what’s possible on a laptop.",
                BrandId = Guid.Parse("BCA0CBC5-1CEA-4444-B613-4E3B4C42FEE0"),
                Discount = 10,
                Price = 1200,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Product()
            {
                Id = Guid.Parse("D750BE8A-97B3-48C1-A72D-AC55C880935B"),
                Title = "Lite Racer Adapt 5.0",
                Description = "These wide fit adidas shoes are crafted with a Cloudfoam midsole and cushioned sockliner for a light and springy feel. They're inspired by running shoes, but work just as well for juggling daily tasks as they do for jogging.",
                BrandId = Guid.Parse("4C9CDADF-C178-439F-866C-517F89810FDF"),
                Discount = 20,
                Price = 100,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
