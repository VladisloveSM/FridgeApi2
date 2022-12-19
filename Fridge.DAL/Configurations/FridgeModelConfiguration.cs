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
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData
                (
                    new FridgeModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Atlanta",
                        Year = 1998
                    },
                    new FridgeModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Horizon",
                        Year = 1993
                    },
                    new FridgeModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "LG",
                        Year = 2001
                    },
                    new FridgeModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Philips",
                        Year = 2000
                    },
                    new FridgeModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Panasonic",
                        Year = 2003
                    }
                );
        }
    }
}
