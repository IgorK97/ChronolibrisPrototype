using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик команды для добавления новой закладки (<see cref="Bookmark"/>).
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/> 
    /// для обработки <see cref="AddBookmarkCommand"/> и возврата <see cref="bool"/>.
    /// </summary>
    public class AddBookmarkHandler : IRequestHandler<AddBookmarkCommand, bool>
    {
        /// <summary>
        /// Приватное поле для доступа к паттерну Unit of Work и репозиториям.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddBookmarkHandler"/>.
        /// </summary>
        /// <param name="unitOfWork">Интерфейс Unit of Work для взаимодействия с базой данных.</param>
        public AddBookmarkHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Обрабатывает команду добавления закладки.
        /// </summary>
        /// <param name="request">Объект команды, содержащий данные для новой закладки.</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию. Результат задачи — <c>true</c> при успехе.</returns>
        public async Task<bool> Handle(AddBookmarkCommand request, CancellationToken cancellationToken)
        {
            //IT WONT WORK, 100%, AAAAAAAAAAAAAAAA
            //TODO: FIX THIS!!! - нет проверки на то, что такая закладка уже есть (потом исправлю тип сущности и все будет работать)

            var bookmark = new Bookmark
            {
                BookId = request.bookId,
                UserId = request.userId,
                Mark = request.mark,
                CreatedAt = DateTime.UtcNow,
                Id = 0,
            };
            // Добавление закладки в контекст (не сохраняется в БД, пока не вызван SaveChangesAsync)
            await _unitOfWork.Bookmarks.AddAsync(bookmark, cancellationToken);
            // Сохранение изменений в базе данных
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            // Возврат true (что не идеально, так как не сообщает о типе ошибки)
            return true;
        }
    }

}
