using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronolibris.Infrastructure.Configurations
{
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            //builder.ToTable("bookmarks");

            //builder.HasOne(b => b.Book)
            //       .WithMany()
            //       .HasForeignKey(b => b.BookId);

            builder.HasOne<User>() // Указываем класс User как целевую сущность
                   .WithMany()     // У пользователя много закладок
                   .HasForeignKey(b => b.UserId) // FK в таблице bookmarks
                   .HasPrincipalKey(u => u.Id);  // PK в таблице AspNetUsers (Id)
                                                 // Имя таблицы "AspNetUsers" EF Core уже знает, так как User наследует от IdentityUser.
        }
    }
}
