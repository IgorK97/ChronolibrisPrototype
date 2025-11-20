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
    public class BookConfiguration :IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(b => b.Persons)
                .WithMany(b => b.Books)
                .UsingEntity<Participation>();

            builder.HasMany(b => b.Shelves)
                .WithMany(s => s.Books)
                .UsingEntity("books_shelves");

            builder.HasMany(b => b.Selections)
                .WithMany(s => s.Books)
                .UsingEntity("books_selections");

            //builder.HasMany(b => b.Contents)
            //    .WithMany(c => c.Books)
            //    .UsingEntity(j => j.ToTable("books_contents"));

            DateTime dt = new DateTime(2025, 11, 20, 0, 0, 0, DateTimeKind.Utc);


            builder.HasData(
                new Book
                {
                    Id = 1,
                    AverageRating = 0,
                    CountryId = 1, // Россия
                    CoverPath = "BuddismHistory/BuddismJapanGrig/MainFile.png",
                    CreatedAt = dt,
                    Description = "Монография является первой в отечественной литературе попыткой...",
                    FilePath = "BuddismHistory/BuddismJapanGrig/MainFile.epub",
                    IsAvailable = true,
                    IsFragment = false,
                    LanguageId = 2, // Русский
                    RatingsCount = 0,
                    ReviewsCount = 0,
                    Title = "Буддизм в Японии",
                    Year = 1993,
                    PublisherId = 2, // Восточная литература
                },
                new Book
                {
                    Id = 2,
                    AverageRating = 0,
                    CountryId = 1, // Россия
                    CoverPath = "EconomicHistory/StructureBrodel/MainFile.png",
                    CreatedAt = dt,
                    Description = "Это — второе крупное исследование Ф. Броделя...",
                    FilePath = "EconomicHistory/StructureBrodel/MainFile.epub",
                    IsAvailable = true,
                    IsFragment = false,
                    LanguageId = 2, // Русский
                    RatingsCount = 0,
                    ReviewsCount = 0,
                    Title = "Структуры повседневности: возможное и невозможное",
                    Year = 1986,
                    PublisherId = 1, // Прогресс
                }
            );

        }
    }
}
