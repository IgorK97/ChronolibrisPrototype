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
    public class PersonRoleConfiguration : IEntityTypeConfiguration<PersonRole>
    {
        public void Configure(EntityTypeBuilder<PersonRole> builder)
        {
            builder.HasData(
                new PersonRole { Id = 1, Name = "Автор" },
                new PersonRole { Id = 2, Name = "Переводчик" },
                new PersonRole { Id = 3, Name = "Редактор" }
            );
        }
    }
}
