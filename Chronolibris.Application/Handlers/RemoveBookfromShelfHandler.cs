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
    /// <summary>
    /// Обработчик (Handler) для команды <see cref="RemoveBookFromShelfCommand"/>.
    /// Отвечает за удаление указанной книги с указанной полки в системе и сохранение изменений.
    /// </summary>
    public class RemoveBookFromShelfHandler : IRequestHandler<RemoveBookFromShelfCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RemoveBookFromShelfHandler"/>.
        /// </summary>
        /// <param name="uow">Единица работы (Unit of Work) для доступа к репозиториям и управления транзакциями.</param>
        public RemoveBookFromShelfHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Обрабатывает команду на удаление книги с полки асинхронно.
        /// </summary>
        /// <param name="request">Команда, содержащая <see cref="RemoveBookFromShelfCommand.ShelfId"/> 
        /// и <see cref="RemoveBookFromShelfCommand.BookId"/> удаляемой книги.</param>
        /// <param name="ct">Токен отмены для прерывания операции.</param>
        /// <returns>Возвращает <c>true</c>, если удаление книги с полки и сохранение изменений прошли успешно.</returns>
        public async Task<bool> Handle(RemoveBookFromShelfCommand request, CancellationToken ct)
        {
            await _uow.Shelves.RemoveBookFromShelf(request.ShelfId, request.BookId, ct);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }

}
