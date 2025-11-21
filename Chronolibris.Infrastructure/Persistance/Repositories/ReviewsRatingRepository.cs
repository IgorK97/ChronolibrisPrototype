using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chronolibris.Infrastructure.Persistance.Repositories
{
    /// <summary>
    /// Репозиторий для управления сущностями оценок отзывов (<see cref="ReviewsRating"/>), 
    /// которые представляют собой голос пользователя (например, лайк или дизлайк) за конкретный отзыв.
    /// Предоставляет специализированные методы доступа к данным, расширяя <see cref="GenericRepository{TEntity}"/>.
    /// Реализует интерфейс <see cref="IReviewsRatingRepository"/>.
    /// </summary>
    public class ReviewsRatingRepository : GenericRepository<ReviewsRating>, IReviewsRatingRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ReviewsRatingRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных приложения, используемый для доступа к данным.</param>
        public ReviewsRatingRepository(ApplicationDbContext context) : base(context) { }

        /// <summary>
        /// Асинхронно получает существующую оценку отзыва (<see cref="ReviewsRating"/>), 
        /// поставленную конкретным пользователем.
        /// </summary>
        /// <param name="reviewId">Идентификатор отзыва, для которого ищется оценка.</param>
        /// <param name="userId">Идентификатор пользователя, который поставил оценку.</param>
        /// <param name="token">Токен отмены для прерывания запроса.</param>
        /// <returns>
        /// Задача, которая представляет асинхронную операцию. Результат задачи — 
        /// сущность <see cref="ReviewsRating"/> (существующий голос) или <c>null</c>, 
        /// если пользователь еще не голосовал за этот отзыв.
        /// </returns>
        public async Task<ReviewsRating?> GetReviewsRatingByUserIdAsync(long reviewId, long userId, CancellationToken token)
        {
            return await _context.ReviewsRatings.FirstOrDefaultAsync(rr => rr.UserId == userId && rr.ReviewId==reviewId, token);
        }
    }
}
