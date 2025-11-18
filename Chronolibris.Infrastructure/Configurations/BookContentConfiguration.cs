using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronolibris.Infrastructure.Configurations
{
    //public class BookContentConfiguration : IEntityTypeConfiguration<BookContent>
    //{
    //    public void Configure(EntityTypeBuilder<BookContent> builder)
    //    {
    //        builder
    //            .ToTable("books_contents")
    //            .HasKey(bc => new { bc.BookId, bc.ContentId });
    //        builder
    //            .HasOne(bc => bc.Book)
    //            .WithMany(b => b.Contents)
    //            .HasForeignKey(bc => bc.BookId);

    //        builder
    //            .HasOne(bc => bc.Content)
    //            .WithMany(c => c.Books)
    //            .HasForeignKey(bc => bc.ContentId);
    //    }
    //}
}
