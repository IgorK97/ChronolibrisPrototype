using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Domain.Models;
using MediatR;

namespace Chronolibris.Application.Requests.References.Tags
{
    public record GetChildTagsQuery(long parentId,long? lastId,int pageSize) : IRequest<PagedResult<TagDetails>>;
}
