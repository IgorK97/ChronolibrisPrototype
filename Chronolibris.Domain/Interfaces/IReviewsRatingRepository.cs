using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;

namespace Chronolibris.Domain.Interfaces
{
    /// <summary>
    /// Определяет контракт для репозитория, управляющего сущностями <see cref="ReviewsRating"/> (оценки отзывов).
    /// Наследует базовые операции CRUD от <see cref="IGenericRepository{T}"/>.
    /// </summary>
    public interface IReviewsRatingRepository : IGenericRepository<ReviewsRating>
    {
        /// <summary>
        /// Асинхронно получает существующую оценку отзыва, поставленную конкретным пользователем.
        /// Используется для проверки, поставил ли пользователь уже "лайк" или "дизлайк" на указанный отзыв.
        /// </summary>
        /// <param name="reviewId">Идентификатор отзыва, на который ищется оценка.</param>
        /// <param name="userId">Идентификатор пользователя, поставившего оценку.</param>
        /// <param name="token">Токен отмены для прерывания операции. По умолчанию — <c>default</c>.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// сущность <see cref="ReviewsRating"/> или <c>null</c>, если пользователь еще не голосовал за этот отзыв.
        /// </returns>
        Task<ReviewsRating?> GetReviewsRatingByUserIdAsync(long reviewId, long userId, CancellationToken token = default);
    }
}
