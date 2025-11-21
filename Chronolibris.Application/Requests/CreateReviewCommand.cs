using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{
    /// <summary>
    /// Команда для создания нового отзыва (рецензии) на книгу.
    /// <para>
    /// Этот класс используется для передачи всех необходимых данных 
    /// для регистрации отзыва в системе.
    /// </para>
    /// </summary>
    public class CreateReviewCommand : IRequest<long>
    {
        /// <summary>
        /// Идентификатор книги, на которую пишется отзыв.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public long BookId { get; init; }

        /// <summary>
        /// Идентификатор пользователя, создающего отзыв.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public long UserId { get; init; }

        /// <summary>
        /// Заголовок отзыва (необязательный).
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public string? Title { get; init; }

        /// <summary>
        /// Текст отзыва или рецензии (необязательный).
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// Оценка, которую пользователь ставит книге в этом отзыве (например, от 1 до 5).
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public short Score { get; init; }

        /// <summary>
        /// Имя пользователя, которое будет отображаться рядом с отзывом (необязательный).
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public string? UserName { get; init; }
    }
}
