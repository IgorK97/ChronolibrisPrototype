using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.DTOs
{
    public class RegisterRequest
    {
        public required string Name { get; set; }
        public required string FamilyName { get; set; }
        public required string Email { get; set; } = default!;
        public required string Password { get; set; } = default!;
    }
}
