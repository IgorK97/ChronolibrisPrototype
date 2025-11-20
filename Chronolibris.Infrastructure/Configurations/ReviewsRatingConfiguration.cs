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
    public class ReviewsRatingConfiguration : IEntityTypeConfiguration<ReviewsRating>
    {
        public void Configure(EntityTypeBuilder<ReviewsRating> builder)
        {
            builder.HasOne<User>() 
                  .WithMany()     
                  .HasForeignKey(b => b.UserId) 
                  .HasPrincipalKey(u => u.Id);
        }
    }
}
