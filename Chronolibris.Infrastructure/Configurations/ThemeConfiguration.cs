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
            builder.HasMany(th => th.SubThemes)
                .WithOne(th => th.ParentTheme)
                .HasForeignKey(th=>th.ParentThemeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Theme { Id = 1, Name = "История" },
                new Theme { Id = 2, Name = "Археология" },
                new Theme { Id = 3, Name = "Философия" },
                new Theme { Id = 4, Name = "Религия" },

                    new Theme { Id = 5, Name = "Всеобщая и мировая история", ParentThemeId = 1 },
                    new Theme { Id = 6, Name = "Региональная и национальная история", ParentThemeId = 1 },
                        new Theme { Id = 7, Name = "История Европы", ParentThemeId=6 },
                            new Theme { Id = 8, Name = "История России", ParentThemeId=7 },
                        new Theme { Id = 9, Name = "История Азии", ParentThemeId = 6 },
                        new Theme { Id = 10, Name = "История Африки" , ParentThemeId = 6 },
                        new Theme { Id = 11, Name = "История Америки" , ParentThemeId = 6 },
                        new Theme { Id = 12, Name = "История Австралазии и Тихоокеании" , ParentThemeId = 6 },
                        new Theme { Id = 13, Name = "История других земель" , ParentThemeId = 6 },
                    new Theme { Id = 14, Name = "История от древнейших времен до сегодняшнего дня" , ParentThemeId=1},
                        new Theme { Id = 15, Name = "История Древнего мира",ParentThemeId=14 },
                        new Theme { Id = 16, Name = "История Средневековья",ParentThemeId=14 },
                        new Theme { Id = 17, Name = "История Нового времени", ParentThemeId = 14 },
                        new Theme { Id = 18, Name = "История 20 века", ParentThemeId = 14 },
                        new Theme { Id = 19, Name = "История 21 века", ParentThemeId = 14 },
                    new Theme { Id = 20, Name = "История: отдельные темы и события", ParentThemeId = 1 },
                    new Theme { Id = 21, Name = "Военная история", ParentThemeId = 1 },
                        new Theme { Id = 22, Name = "Гражданская война в России", ParentThemeId = 21 },
                        new Theme { Id = 23, Name = "Первая мировая война", ParentThemeId = 21 },
                        new Theme { Id = 24, Name = "Вторая мировая война", ParentThemeId = 21 },
                        new Theme { Id = 25, Name = "Крымская война", ParentThemeId = 21 },


                    new Theme { Id = 26, Name = "История западной философии", ParentThemeId = 3 },
                        new Theme { Id = 27, Name = "Античная философия", ParentThemeId = 26 },
                        new Theme { Id = 28, Name = "Философия Средних веков и эпохи Ренессанса", ParentThemeId = 26 },
                        new Theme { Id = 29, Name = "Философия эпохи Нового времени", ParentThemeId = 26 },
                        new Theme { Id = 30, Name = "Современная философия", ParentThemeId = 26 },
                    new Theme { Id = 31, Name = "Восточная философия", ParentThemeId = 3 },
                    new Theme { Id = 32, Name = "Исламская и арабская философия", ParentThemeId = 3 },
                    new Theme { Id = 33, Name = "Социальная и политическая философия", ParentThemeId = 3 },


                    new Theme { Id = 34, Name = "Христианство", ParentThemeId = 4 },
                    new Theme { Id = 35, Name = "Буддизм", ParentThemeId = 4},
                    new Theme { Id = 36, Name = "Ислам", ParentThemeId = 4 }



            );
        }
    }
}
