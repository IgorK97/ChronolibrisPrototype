using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class AddBookToShelfHandler : IRequestHandler<AddBookToShelfCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public AddBookToShelfHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(AddBookToShelfCommand request, CancellationToken ct)
        {
            await _uow.Shelves.AddBookToShelf(request.ShelfId, request.BookId);
            await _uow.SaveChangesAsync();
            return true;
        }
    }

}
