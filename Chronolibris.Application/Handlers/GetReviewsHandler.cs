using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using MediatR;
using Chronolibris.Domain.Interfaces;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик запроса для получения списка отзывов (<see cref="ReviewDetails"/>) для конкретной книги.
    /// Использует первичный конструктор для внедрения зависимости <see cref="IReviewRepository"/>.
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="GetReviewsQuery"/> и возврата списка <see cref="List{T}"/> из <see cref="ReviewDetails"/>.
    /// </summary>
    public class GetReviewsHandler(IReviewRepository reviewRepository) : IRequestHandler<GetReviewsQuery, List<ReviewDetails>>
    {

        // Примечание: Внедрение зависимости через первичный конструктор (Primary Constructor)
        // автоматически создает приватное поле только для чтения `reviewRepository`.

        /// <summary>
        /// Обрабатывает запрос на получение отзывов для указанной книги.
        /// </summary>
        /// <remarks>
        /// **Оптимизированная логика:**
        /// <list type="bullet">
        /// <item>Использует метод <c>GetByBookIdAsync</c> (или аналогичный) для получения только нужных отзывов из базы данных, 
        /// вместо загрузки всех отзывов (<c>GetAllAsync</c>) и фильтрации их в памяти.</item>
        /// <item>Выполняет маппинг сущностей <c>Review</c> на <see cref="ReviewDetails"/> DTO.</item>
        /// </list>
        /// </remarks>
        /// <param name="request">Запрос, содержащий идентификатор книги (<c>BookId</c>).</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию.
        /// Результат задачи — список <see cref="ReviewDetails"/>, содержащий отзывы, 
        /// или пустой список, если отзывы не найдены.
        /// </returns>
        public async Task<List<ReviewDetails>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            //var reviews = await reviewRepository.GetAllAsync(cancellationToken);
            //return reviews.Where(r => r.BookId == request.BookId)
            //    .Select(r => new ReviewDetails
            //    {
            //        Id = r.Id,
            //        AverageRating = r.AverageRating,
            //        Text = r.Description,

            //        DislikesCount = r.DislikesCount,
            //        LikesCount = r.LikesCount,
            //        UserName = r.Name,
            //        Score = r.Score,
            //        Title = r.Title,
            //        CreatedAt = r.CreatedAt,
            //    }).ToList(); // i should fix this code later (1 - where, 2 - mapping)
            var reviews = await reviewRepository.GetByBookIdAsync(request.BookId, cancellationToken);

            // Если GetByBookIdAsync возвращает null, возвращаем пустой список
            if (reviews == null)
            {
                return new List<ReviewDetails>();
            }

            // 2. Оптимизация маппинга: Select для преобразования сущностей в DTO.
            return reviews
                .Select(r => new ReviewDetails
                {
                    Id = r.Id,
                    AverageRating = r.AverageRating,
                    Text = r.Description, // Маппинг Description на Text
                    DislikesCount = r.DislikesCount,
                    LikesCount = r.LikesCount,
                    UserName = r.Name,
                    Score = r.Score,
                    Title = r.Title,
                    CreatedAt = r.CreatedAt,
                }).ToList();
        }
    }

}
