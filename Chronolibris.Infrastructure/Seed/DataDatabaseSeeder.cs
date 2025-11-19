using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace Chronolibris.Infrastructure.Seed
{
    public class DataDatabaseSeeder
    {
        public static async Task ThemeSeedDatabase(ApplicationDbContext context)
        {
            if (!context.Themes.Any())
            {
                var themes = new[]
                {
                new Theme { Id = 0, Name = "Отечественная история" },
                new Theme { Id = 0, Name = "История религии" },
                new Theme { Id = 0, Name = "История культуры" },
                new Theme { Id = 0, Name = "Социально-экономическая история" }
            };

                context.Themes.AddRange(themes);
                await context.SaveChangesAsync();
            }
        }

        public static async Task LanguageSeedDatabase(ApplicationDbContext context)
        {
            if (!context.Languages.Any())
            {
                var languages = new[]
                {
                new Language { Id = 0, Name = "Английский" },
                new Language { Id = 0, Name = "Русский" },
                new Language { Id = 0, Name = "Французский" },
                new Language { Id = 0, Name = "Немецкий" }
            };

                context.Languages.AddRange(languages);
                await context.SaveChangesAsync();
            }
        }
        public static async Task CountrySeedDatabase(ApplicationDbContext context)
        {
            if (!context.Countries.Any())
            {
                var countries = new[]
                {
                new Country { Id = 0, Name = "Россия" },
                new Country { Id = 0, Name = "СССР" },
                new Country { Id = 0, Name = "Российская империя" },
                new Country { Id = 0, Name = "США" },
                new Country { Id = 0, Name = "Франция" }
            };

                context.Countries.AddRange(countries);
                await context.SaveChangesAsync();
            }
        }
        public static async Task ContentsSeedDatabase(ApplicationDbContext context)
        {
            if (!context.Contents.Any())
            {
                DateTime dt = DateTime.UtcNow;
                var contents = new[]
                {
                    new Content
                    {
                        CountryId=1,
                        CreatedAt = dt,
                        Description = "Монография является первой в отечественной " +
                        "литературе попыткой проследить процесс становления японского буддизма, " +
                        "проанализировать объективные и субъективные факторы социально-политического и культурного характера, " +
                        "определившие облик этой идеологии на Японских островах, выяснить специфические черты, которые приобрел буддизм в Японии, " +
                        "его роль в обществе и влияние на формирование общественной мысли и культуры страны. Приведены выдержки из трудов Нитирэна, Догэна, " +
                        "Эйсая и других трактатов, излагающих основы учений",
                        Id = 0,
                        IsOriginal = true,
                        IsTranslate=false,
                        LanguageId=2,
                        Position=0,
                        Title="Буддизм в Японии",
                        Year=1993,

                    },
                    new Content
                    {
                        CountryId=5,
                        CreatedAt = dt,
                        Description = "Это — второе крупное исследование Ф. Броделя. Первое — «Средиземное море и мир Средиземноморья в эпоху Филиппа II»" +
                        " — было опубликовано в 1949 г. В течение тридцати лет, разделяющих эти две даты, Ф. Бродель занимал центральное место во французской " +
                        "историографии. После Марка Блока (1886–1944 гг.) и Люсьена Февра (1878–1956 гг.) — основателей исторической школы «Анналов» — Ф. Бродель, " +
                        "став общепризнанным лидером этого научного направления, продолжил их «битвы за историю»2, предназначением которой, как они считали, должно " +
                        "было стать не простое описание событий, не беззаботное повествование о них, а проникновение в глубины исторического движения, стремление к синтезу, " +
                        "к охвату и объяснению всех сторон жизни общества в их единстве. " +
                        "Две основные работы Ф. Броделя и представляют собой конкретную попытку такого исторического синтеза: в одном случае в масштабе " +
                        "крупного Средиземноморского региона XVI в., а в другом — в масштабе всего человечества с XV по XVIII в.Эти работы — высшее достижение " +
                        "школы «Анналов», лучшее выражение присущего этому историографическому направлению способа воссоздания истории, а их автор Ф. Бродель — " +
                        "оригинальный мыслитель, один из крупнейших современных историков, достойный представитель прогрессивной французской интеллигенции, " +
                        "способствовавший укреплению интернациональных связей между учеными всех стран, в частности между французскими и советскими историками. " +
                        "Как исследователь он всегда выбирал непроторенные пути, отыскивал для решения сложные проблемы.Не все они, разумеется, решались одинаково " +
                        "успешно, но в целом творческие поиски Ф. Броделя оказались весьма плодотворными.",
                        Id = 0,
                        IsOriginal = false,
                        IsTranslate=true,
                        LanguageId=2,
                        Position=0,
                        Title="Структуры повседневности: возможное и невозможное",
                        Year=1979,

                    },
                };

                context.Contents.AddRange(contents);
                await context.SaveChangesAsync();

                long[] personIds = context.Persons.Select(p => p.Id).ToArray();

                var participations = new List<Participation>();

                participations.Add(new Participation
                {
                    Id = 0,
                    ContentId = 1,
                    PersonId = 1,
                    PersonRoleId = 1,
                });

                participations.Add(new Participation
                {
                    Id = 0,
                    ContentId = 2,
                    PersonId = 2,
                    PersonRoleId = 1,
                });

                context.Participations.AddRange(participations);
                await context.SaveChangesAsync();

            }
        }
        public static async Task BooksSeedDatabase(ApplicationDbContext context)
        {

            if (!context.Books.Any())
            {
                DateTime dt = DateTime.UtcNow;

                var content1 = await context.Contents.FirstAsync(c => c.Id==1);
                var content2 = await context.Contents.FirstAsync(c => c.Id==2);


                var books = new[]
                {
                    new Book
                    {
                        AverageRating=0,
                        CountryId=1,
                        CoverPath="BuddismHistory/BuddismJapanGrig/MainFile.png",
                        CreatedAt=dt,
                        Description="Монография является первой в отечественной " +
                        "литературе попыткой проследить процесс становления японского буддизма, " +
                        "проанализировать объективные и субъективные факторы социально-политического и культурного характера, " +
                        "определившие облик этой идеологии на Японских островах, выяснить специфические черты, которые приобрел буддизм в Японии, " +
                        "его роль в обществе и влияние на формирование общественной мысли и культуры страны. Приведены выдержки из трудов Нитирэна, Догэна, " +
                        "Эйсая и других трактатов, излагающих основы учений",
                        FilePath="BuddismHistory/BuddismJapanGrig/MainFile.epub",
                        Id=0,
                        IsAvailable=true,
                        IsFragment=false,
                        LanguageId=2,
                        RatingsCount=0,
                        ReviewsCount=0,
                        Title="Буддизм в Японии",
                        Year=1993,
                        PublisherId=2,
                        Contents = new List<Content> { content1 }
                    },
                    new Book
                    {
                        AverageRating=0,
                        CountryId=1,
                        CoverPath="EconomicHistory/StructureBrodel/MainFile.png",
                        CreatedAt=dt,
                        Description="Это — второе крупное исследование Ф. Броделя. Первое — «Средиземное море и мир Средиземноморья в эпоху Филиппа II»" +
                        " — было опубликовано в 1949 г. В течение тридцати лет, разделяющих эти две даты, Ф. Бродель занимал центральное место во французской " +
                        "историографии. После Марка Блока (1886–1944 гг.) и Люсьена Февра (1878–1956 гг.) — основателей исторической школы «Анналов» — Ф. Бродель, " +
                        "став общепризнанным лидером этого научного направления, продолжил их «битвы за историю»2, предназначением которой, как они считали, " +
                        "должно было стать не простое описание событий, не беззаботное повествование о них, а проникновение в глубины исторического движения, " +
                        "стремление к синтезу, к охвату и объяснению всех сторон жизни общества в их единстве.\r\n\r\nДве основные работы Ф. Броделя и представляют " +
                        "собой конкретную попытку такого исторического синтеза: в одном случае в масштабе крупного Средиземноморского региона XVI в., а в другом — " +
                        "в масштабе всего человечества с XV по XVIII в. Эти работы — высшее достижение школы «Анналов», лучшее выражение присущего этому " +
                        "историографическому направлению способа воссоздания истории, а их автор Ф. Бродель — оригинальный мыслитель, один из крупнейших " +
                        "современных историков, достойный представитель прогрессивной французской интеллигенции, способствовавший укреплению интернациональных " +
                        "связей между учеными всех стран, в частности между французскими и советскими историками. Как исследователь он всегда выбирал непроторенные " +
                        "пути, отыскивал для решения сложные проблемы. Не все они, разумеется, решались одинаково успешно, но в целом творческие поиски Ф. Броделя " +
                        "оказались весьма плодотворными.",
                        FilePath="EconomicHistory/StructureBrodel/MainFile.epub",
                        Id=0,
                        IsAvailable=true,
                        IsFragment=false,
                        LanguageId=2,
                        RatingsCount=0,
                        ReviewsCount=0,
                        Title="Структуры повседневности: возможное и невозможное",
                        Year=1986,
                        PublisherId=1,
                        Contents = new List<Content> { content2 }
                    },
                };
            }

        }

        public static async Task SelectionSeedDatabase(ApplicationDbContext context)
        {
            if (!context.Selections.Any())
            {
                DateTime dt = DateTime.UtcNow;
                var selections = new[]
                {
                    new Selection
                    {
                        CreatedAt=dt,
                        Description="",
                        Id=0,
                        IsActive=true,
                        Name="Экономическая история",

                    },
                    new Selection
                    {
                        CreatedAt=dt,
                        Description="",
                        Id=0,
                        IsActive=true,
                        Name="История культуры",
                    },
                    new Selection
                    {
                        CreatedAt = dt,
                        Description="",
                        Id=0,
                        IsActive=true,
                        Name="История мира"
                    }
                };

                context.Selections.AddRange(selections);
                await context.SaveChangesAsync();
            }
        }

        public static async Task PersonSeedDatabase(ApplicationDbContext context)
        {
            if (!context.Persons.Any())
            {
                DateTime dt = DateTime.UtcNow;
                var persons = new[]
                {
                    new Person
                    {
                        CreatedAt=dt,
                        Id=0,
                        Name="Татьяна Петровна Григорьева",
                        ImagePath="none",
                        Description="Советский и российский востоковед-японист, литературовед, " +
                        "переводчица, доктор филологических наук, заслуженный деятель науки РФ. Родилась 18 декабря 1929 года в ленинграде, " +
                        "РСФСР. Умерла 22 декабря 2014 года в Москве. "
                    },
                    new Person
                    {
                        CreatedAt=dt,
                        Id=0,
                        Name="Фернан Поль Ахилл Бродель",
                        ImagePath="Brodel/MainFile.jpeg",
                        Description="Французский историк, член Французской академии. " +
                        "Представитель французской школы \"Анналов\", занимавшейся доскональным изучением исторических феноменов в социальных науках. Родился" +
                        " 24 августа 1902 года в Люмевиль-ан-Орнуа. Умер 27 ноября 1985 года в городе Клюз."
                    }
                };
                context.Persons.AddRange(persons);
                await context.SaveChangesAsync();
            }
            if (!context.PersonRoles.Any())
            {
                DateTime dt = DateTime.UtcNow;
                var roles = new[]
                {
                    new PersonRole
                    {
                        Id=0,
                        Name="Автор",

                    },
                    new PersonRole
                    {
                        Id=0,
                        Name="Переводчик",

                    },
                    new PersonRole
                    {
                        Id=0,
                        Name="Редактор"
                    }
                };

                context.PersonRoles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }

        public static async Task PublisherSeedDatabase(ApplicationDbContext context)
        {
            if (!context.Publishers.Any())
            {
                DateTime dt = DateTime.UtcNow;
                var publishers = new[]
                {
                    new Publisher
                    {
                        CountryId=2,
                        CreatedAt=dt,
                        Description="",
                        Id=0,
                        Name="Прогресс",
                    },
                    new Publisher
                    {
                        CountryId=1,
                        CreatedAt=dt,
                        Description="",
                        Id=0,
                        Name="Востояная литература"
                    }
                };

                context.Publishers.AddRange(publishers);
                await context.SaveChangesAsync();
            }
        }

        public static async Task TagTypeSeedDatabase(ApplicationDbContext context)
        {
            if (!context.TagTypes.Any())
            {
                var tagTypes = new[]
                {
                    new TagType
                    {
                        Id = 0,
                        Name="Место",

                    },
                    new TagType
                    {
                        Id=0,
                        Name="Время",
                    },
                    new TagType
                    {
                        Id=0,
                        Name="Персоналия"
                    }
                };
                context.TagTypes.AddRange(tagTypes);
                await context.SaveChangesAsync();
            }
        }
    }
}
