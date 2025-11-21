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
    /// Обработчик (Handler) для команды <see cref="RemoveBookmarkCommand"/>.
    /// Отвечает за поиск закладки по идентификатору, ее удаление 
    /// и сохранение изменений в базе данных.
    /// </summary>
    public class RemoveBookmarkHandler : IRequestHandler<RemoveBookmarkCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RemoveBookmarkHandler"/>.
        /// </summary>
        /// <param name="unitOfWork">Единица работы (Unit of Work) для доступа к репозиториям и управления транзакциями.</param>
        public RemoveBookmarkHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Обрабатывает команду на удаление закладки асинхронно.
        /// </summary>
        /// <param name="request">Команда, содержащая <see cref="RemoveBookmarkCommand.bookmarkId"/> удаляемой закладки.</param>
        /// <param name="cancellationToken">Токен отмены для прерывания операции.</param>
        /// <returns>
        /// Возвращает <c>true</c>, если закладка была найдена, удалена и изменения сохранены.
        /// Возвращает <c>false</c>, если закладка с указанным <paramref name="request"/>.<c>bookmarkId</c> не была найдена.
        /// </returns>
        public async Task<bool> Handle(RemoveBookmarkCommand request, CancellationToken cancellationToken)
        {
            var existing = await _unitOfWork.Bookmarks.GetByIdAsync(request.bookmarkId, cancellationToken);
            if (existing == null)
            {
                return false;
            }

            _unitOfWork.Bookmarks.Delete(existing);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
