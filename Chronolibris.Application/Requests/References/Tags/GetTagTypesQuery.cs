using Chronolibris.Domain.Entities;
using MediatR;

namespace Chronolibris.Application.Requests.References.Tags
{
    public record GetTagTypesQuery():IRequest<List<TagType>>;
}
