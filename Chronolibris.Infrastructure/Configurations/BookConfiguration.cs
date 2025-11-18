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

            builder.HasMany(b => b.Contents)
                .WithMany(c => c.Books)
                .UsingEntity(j => j.ToTable("books_contents"));
        }
    }
}
