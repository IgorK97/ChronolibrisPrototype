using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.OperationResult
{
    public enum ErrorReason
    {
        None,
        NotFound,

    }
    public sealed record Error(ErrorReason Code, string Description)
    {
        public static readonly Error None = new(ErrorReason.None, string.Empty);
    }
}
