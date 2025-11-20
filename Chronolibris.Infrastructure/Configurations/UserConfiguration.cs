using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronolibris.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // 🛑 ВСТАВЬТЕ СЮДА СГЕНЕРИРОВАННЫЙ ХЕШ (ПРИМЕР!)
        private const string AdminPasswordHash = "AQAAAAIAAYagAAAAEDJFJc162io4pjNy1E/Nf//bvX+ki234hGsZCcYkJjtPeR9CZQ1k/4T7Q2i+CWbPMg==";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var dt = new DateTime(2025, 11, 20, 0, 0, 0, DateTimeKind.Utc);

            builder.HasData(
                new User
                {
                    Id = 1,
                    FamilyName = "KQWERTY",
                    IsDeleted = false,
                    LastEnteredAt = dt,
                    Name = "AQWERTY",
                    RegisteredAt = dt,
                    Email = "mail@mail.com",
                    NormalizedEmail = "MAIL@MAIL.COM",
                    UserName = "MainAdmin",
                    NormalizedUserName = "MAINADMIN",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(), 
                    PasswordHash = AdminPasswordHash
                }
            );
        }
    }
}
