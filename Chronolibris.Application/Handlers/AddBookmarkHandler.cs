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
        /// <remarks>
        /// Возвращает <c>true</c> в случае успешного добавления и сохранения в базе данных.
        /// Вы отметили, что "IT WONT WORK, 100%". Если это так, возможные причины:
        /// <list type="bullet">
        /// <item>Нарушение ограничений (Constraint Violation), например, не существующие <c>BookId</c> или <c>UserId</c>.</item>
        /// <item>Проблема с генерацией <c>Id</c> (если вы устанавливаете <c>Id = 0</c>, и Id должен генерироваться базой данных, это обычно нормально).</item>
        /// <item>Проблема в логике репозитория <c>AddAsync</c> или <c>SaveChangesAsync</c>.</item>
        /// </list>
        /// **Для исправления** рекомендуется изменить тип возвращаемого значения с <see cref="bool"/> на <see cref="Result{T}"/> 
        /// (используя Result Pattern, как обсуждалось ранее), чтобы возвращать **конкретную ошибку** вместо просто <c>false</c> или <c>true</c>.
        /// </remarks>
        /// <param name="request">Объект команды, содержащий данные для новой закладки.</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию. Результат задачи — <c>true</c> при успехе.</returns>
        public async Task<bool> Handle(AddBookmarkCommand request, CancellationToken cancellationToken)
        {
            //IT WONT WORK, 100%, AAAAAAAAAAAAAAAA
            //TODO: FIX THIS!!! - нет проверки на то, что такая закладка уже есть (потом исправлю тип сущности и все будет работать)

            var bookmark = new Bookmark
            {
                BookId = request.BookId,
                UserId = request.UserId,
                Mark = request.Mark,
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
