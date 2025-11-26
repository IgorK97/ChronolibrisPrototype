using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public class UpdateReadingProgressCommand : IRequest<bool>
    {
        public long UserId { get; init; }
        public long BookId { get; init; }
        public decimal ReadingProgress { get; init; }
    }
}
