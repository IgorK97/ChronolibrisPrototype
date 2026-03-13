using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronolibris.Infrastructure.DataAccess.Configurations
{
    public class BookFragmentConfiguration : IEntityTypeConfiguration<BookFragment>
    {
        public void Configure(EntityTypeBuilder<BookFragment> builder)
        {
            builder
                .HasIndex(f => new { f.BookFileId, f.Position })
                .IsUnique();
        }
    }
}
