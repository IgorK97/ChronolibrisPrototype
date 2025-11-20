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
    public class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder.HasData(
                new Theme { Id = 1, Name = "Отечественная история" },
                new Theme { Id = 2, Name = "История религии" },
                new Theme { Id = 3, Name = "История культуры" },
                new Theme { Id = 4, Name = "Социально-экономическая история" }
            );
        }
    }
}
