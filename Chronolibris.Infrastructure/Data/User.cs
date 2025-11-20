using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Chronolibris.Infrastructure.Data
{
    public class User : IdentityUser<long>
    {
        //[Key]
        //public required long Id { get; set; }
        //public required string Email { get; set; }

        public required string Name { get; set; }
        //public required string Password { get; set; }
        public required string FamilyName { get; set; }
        public required DateTime RegisteredAt { get; set; }
        public required DateTime LastEnteredAt { get; set; }
        public required bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
       
    }
}
