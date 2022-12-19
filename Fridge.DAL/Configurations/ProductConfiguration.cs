using FridgeApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Banana",
                        DefaultQuantity = 6
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grape",
                        DefaultQuantity = 1
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Apple",
                        DefaultQuantity = 3
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Beaf",
                        DefaultQuantity = 1
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cherry",
                        DefaultQuantity = 8
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Fish",
                        DefaultQuantity = 4,
                    }
                );
        }
    }
}
