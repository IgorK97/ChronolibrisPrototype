using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public record GetChunkQuery(long BookFileId, string ChunkIndex) : IRequest<string?>;
}
