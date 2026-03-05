namespace ChronolibrisPrototype.Models
{
    public class RateCommentRequest
    {

        /// <summary>
        /// Идентификатор отзыва, который пользователь оценивает.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public long CommentId { get; init; }



        /// <summary>
        /// Оценка, которую пользователь ставит отзыву.
        /// Например: <c>1</c> для лайка, <c>-1</c> для дизлайка или <c>0</c> для отмены голоса.
        /// Свойство доступно только для инициализации (<c>init</c>).
        /// </summary>
        public short Score { get; init; }
    }
}
