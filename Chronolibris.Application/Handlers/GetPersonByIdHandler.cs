using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    // 1. Определение запроса. Возвращает объект Person или null, если не найдено.
    public record GetPersonByIdQuery(long Id) : IRequest<Person?>;

    // 2. Обработчик запроса
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person?>
    {
        private readonly IGenericRepository<Person> _repository;

        // Внедряем ваш GenericRepository
        public GetPersonByIdHandler(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            // Используем стандартный метод из вашего GenericRepository
            return await _repository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}