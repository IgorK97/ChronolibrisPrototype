using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public string Message { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
