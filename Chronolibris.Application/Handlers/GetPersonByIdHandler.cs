using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public record GetPersonByIdQuery(long Id) : IRequest<Person?>;
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person?>
    {
        private readonly IGenericRepository<Person> _repository;
        public GetPersonByIdHandler(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}