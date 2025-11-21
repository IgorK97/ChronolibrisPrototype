using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using MediatR;

namespace Chronolibris.Application.Requests
{
    /// <summary>
    /// Команда для оценки отзыва (например, лайк или дизлайк) указанным пользователем.
    /// <para>
    /// Этот класс используется для передачи всех необходимых данных 
    /// для регистрации голоса пользователя за конкретный отзыв.
    /// </para>
    /// </summary>
    public class RateReviewCommand : IRequest<ReviewDetails?>
    {
        /// <summary>
        /// Идентификатор отзыва, который пользователь оценивает.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public long ReviewId { get; init; }

        /// <summary>
        /// Идентификатор пользователя, который ставит оценку.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public long UserId { get; init; }

        /// <summary>
        /// Оценка, которую пользователь ставит отзыву.
        /// Например: <c>1</c> для лайка, <c>-1</c> для дизлайка или <c>0</c> для отмены голоса.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public short Score { get; init; }
    }
}
