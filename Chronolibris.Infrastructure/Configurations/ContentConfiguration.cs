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
    public class ContentConfiguration :IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            //builder.HasMany(c => c.Books)
            //    .WithMany(b => b.Contents)
            //    .UsingEntity<ContentBook>();

            builder.HasMany(c => c.Persons)
                .WithMany(p => p.Contents)
                .UsingEntity<Participation>();

            builder.HasMany(c => c.Themes)
                .WithMany(th => th.Contents)
                .UsingEntity("contents_themes");
        }
    }
}
