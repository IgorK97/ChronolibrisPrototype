using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Infrastructure.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronolibris.Infrastructure.DataAccess.Configurations
{
    //public class BookVectorConfiguration : IEntityTypeConfiguration<BookVector>
    //{
    //    public void Configure(EntityTypeBuilder<BookVector> builder)
    //    {
    //        builder.HasKey(e => e.BookId);
    //        builder.HasOne<Book>()
    //            .WithOne()
    //            .HasForeignKey<BookVector>(bc=>bc.BookId)
    //            //.HasForeignKey("book_vectors", "book_id")
    //            .OnDelete(DeleteBehavior.Cascade);

    //        builder.HasIndex(e => e.SearchVector)
    //              .HasMethod("GIN");
    //    }
    //}
}
