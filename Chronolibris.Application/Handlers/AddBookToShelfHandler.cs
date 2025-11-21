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
    /// Обработчик команды для добавления книги на полку.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/> 
    /// для обработки <see cref="AddBookToShelfCommand"/> и возврата <see cref="bool"/>.
    /// </summary>
    public class AddBookToShelfHandler : IRequestHandler<AddBookToShelfCommand, bool>
    {
        /// <summary>
        /// Приватное поле только для чтения для доступа к Unit of Work.
        /// </summary>
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddBookToShelfHandler"/>.
        /// </summary>
        /// <param name="uow">Интерфейс Unit of Work для взаимодействия с базой данных.</param>
        public AddBookToShelfHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Обрабатывает команду добавления книги на указанную полку.
        /// </summary>
        /// <remarks>
        /// Метод вызывает соответствующий репозиторий для добавления книги, 
        /// а затем сохраняет изменения в базе данных.
        /// </remarks>
        /// <param name="request">Объект команды, содержащий идентификаторы ShelfId и BookId.</param>
        /// <param name="ct">Токен отмены (CancellationToken) для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию. 
        /// Результат задачи — <c>true</c> при успешном выполнении. 
        /// </returns>
        public async Task<bool> Handle(AddBookToShelfCommand request, CancellationToken ct)
        {
            // Вызов метода репозитория для добавления книги на полку
            await _uow.Shelves.AddBookToShelf(request.ShelfId, request.BookId, ct);
            // Сохранение всех ожидающих изменений в базе данных
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }

}
