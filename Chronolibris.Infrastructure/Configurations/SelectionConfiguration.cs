using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronolibris.Infrastructure.Configurations
{
    public class SelectionConfiguration : IEntityTypeConfiguration<Selection>
    {
        public void Configure(EntityTypeBuilder<Selection> builder)
        {
            DateTime dt = new DateTime(2025, 11, 20, 0, 0, 0, DateTimeKind.Utc);


            builder.HasData(
                new Selection
                {
                    Id = 1,
                    CreatedAt = dt,
                    Description = "",
                    IsActive = true,
                    Name = "Экономическая история",
                    SelectionTypeId=3
                },
                new Selection
                {
                    Id = 2,
                    CreatedAt = dt,
                    Description = "",
                    IsActive = true,
                    Name = "История культуры",
                    SelectionTypeId = 3

                },
                new Selection
                {
                    Id = 3,
                    CreatedAt = dt,
                    Description = "",
                    IsActive = true,
                    Name = "История мира",
                    SelectionTypeId = 3

                },
                new Selection
                {
                    Id = 4,
                    CreatedAt = dt,
                    Description = "",
                    IsActive = true,
                    Name = "Новое",
                    SelectionTypeId = 1
                },
                new Selection {                     
                    Id = 5,
                    CreatedAt = dt,
                    Description = "",
                    IsActive = true,
                    Name = "Часто читают",
                    SelectionTypeId = 2
                }
            );
        }
    }
}
