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
    public class ParticipationConfiguration : IEntityTypeConfiguration<Participation>
    {
        public void Configure(EntityTypeBuilder<Participation> builder)
        {
            builder.HasData(
                new Participation
                {
                    Id = 1,
                    ContentId = 1, // "Буддизм в Японии"
                    PersonId = 1, // Татьяна Петровна Григорьева
                    PersonRoleId = 1, // Автор
                },
                new Participation
                {
                    Id = 2,
                    ContentId = 2, // "Структуры повседневности..."
                    PersonId = 2, // Фернан Поль Ахилл Бродель
                    PersonRoleId = 1, // Автор
                }
            );
        }
    }
}
