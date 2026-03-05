using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Domain.Models;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public class RateCommentCommand : IRequest<CommentDto?>
    {
        /// <summary>
        /// Идентификатор отзыва, который пользователь оценивает.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public long CommentId { get; init; }

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
