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
    public class ReviewsRatingConfiguration : IEntityTypeConfiguration<ReviewsReaction>
    {
        public void Configure(EntityTypeBuilder<ReviewsReaction> builder)
        {
            builder.ToTable(rr=>rr.HasCheckConstraint("ck_reviews_reactions_reaction_type",
                "reaction_type IN (1, -1, 0)"));

            builder.HasOne<User>() 
                  .WithMany()     
                  .HasForeignKey(b => b.UserId) 
                  .HasPrincipalKey(u => u.Id);

            builder.HasIndex(r => new { r.UserId, r.ReviewId })
               .IsUnique();
        }
    }
}
