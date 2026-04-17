using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Requests.Shelves;
using Chronolibris.Domain.Exceptions;
using Chronolibris.Domain.Interfaces.Repository;
using MediatR;

namespace Chronolibris.Application.Handlers.Shelves
{
    public class UpdateShelfCommandHandler : IRequestHandler<UpdateShelfCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        public UpdateShelfCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Unit> Handle(UpdateShelfCommand request, CancellationToken ct)
        {
            //var shelf = await _uow.Shelves.GetByIdAsync(request.ShelfId, ct);
            //if (shelf == null)
            //    throw new ChronolibrisException("Книжная полка не найдена", ErrorType.NotFound);

            //if (shelf.UserId != request.UserId)
            //    throw new ChronolibrisException("Нет прав на совершение данной операции", ErrorType.Forbidden);

            //shelf.Name = request.Name;
            //await _uow.SaveChangesAsync(ct);
            //return Unit.Value;
            int rowsAffected = await _uow.Shelves.UpdateNameByOwnerAsync(
                                                    request.ShelfId,
                                                    request.UserId,
                                                    request.Name,
                                                    ct);

            if (rowsAffected == 0)
            {
                throw new ChronolibrisException("Полка не найдена", ErrorType.NotFound);
            }
            return Unit.Value;
        }
    }
}
