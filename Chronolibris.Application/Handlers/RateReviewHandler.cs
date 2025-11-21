using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    /// <summary>
    /// Обработчик команды для оценки отзыва пользователем (Like, Dislike или снятие оценки).
    /// Реализует интерфейс <see cref="IRequestHandler{TRequest, TResponse}"/>
    /// для обработки <see cref="RateReviewCommand"/> и возврата обновленного <see cref="ReviewDetails"/> DTO.
    /// </summary>
    public class RateReviewHandler : IRequestHandler<RateReviewCommand, ReviewDetails?>
    {
        /// <summary>
        /// Приватное поле только для чтения для доступа к паттерну Unit of Work.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RateReviewHandler"/>.
        /// </summary>
        /// <param name="unitOfWork">Интерфейс Unit of Work для взаимодействия с базой данных.</param>
        public RateReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Обрабатывает команду оценки отзыва.
        /// </summary>
        /// <remarks>
        /// Логика команды включает многоэтапный процесс для обеспечения согласованности данных:
        /// <list type="number">
        /// <item>Получение отзыва для проверки существования и отслеживания.</item>
        /// <item>Обработка изменения/удаления/добавления пользовательской оценки (<c>ReviewsRating</c>).</item>
        /// <item>**Первое сохранение** (<c>SaveChangesAsync</c>): Фиксирует изменение <c>ReviewsRating</c>.</item>
        /// <item>**Атомарный пересчет** (<c>RecalculateRatingAsync</c>): Выполняет безопасное, не зависящее от ORM, обновление счетчиков <c>Review</c> в БД, предотвращая Lost Update.</item>
        /// <item>**Отсоединение и Перезагрузка:** Отключает старую сущность <c>review</c> (`Detach`) и загружает ее заново (`GetByIdAsync`), чтобы получить актуальные счетчики из БД.</item>
        /// </list>
        /// </remarks>
        /// <param name="request">Объект команды, содержащий <c>ReviewId</c>, <c>UserId</c> и новую <c>Score</c> (1: Like, -1: Dislike, 0: Remove).</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>
        /// Задача, представляющая асинхронную операцию.
        /// Результат задачи — обновленный объект <see cref="ReviewDetails"/> с актуальными счетчиками, или <c>null</c>, если отзыв не найден.
        /// </returns>
        public async Task<ReviewDetails?> Handle(RateReviewCommand request, CancellationToken cancellationToken)
        {
            // 1. Получение отзыва. Используем AsNoTracking, так как нам не нужно его изменять сразу, 
            // а атомарное обновление все равно обойдет его.
            // Однако, для проверки существования GetByIdAsync без AsNoTracking - нормально.
            var review = await _unitOfWork.Reviews.GetByIdAsync(request.ReviewId, cancellationToken);
            if (review == null)
                return null;

            // 2. Получение существующей оценки от этого пользователя
            var rating = await _unitOfWork.ReviewsRatings.GetReviewsRatingByUserIdAsync(request.ReviewId,
                request.UserId, cancellationToken);

            // --- Логика изменения/удаления оценки (ReviewsRating) ---
            if (request.Score == 0) // Снятие оценки
            {
                if (rating != null)
                    _unitOfWork.ReviewsRatings.Delete(rating);
            }
            else // Установка или изменение оценки
            {
                if (rating == null)
                {
                    rating = new ReviewsRating
                    {
                        Id = 0,
                        ReviewId = request.ReviewId,
                        Score = request.Score,
                        UserId = request.UserId,
                    };
                    await _unitOfWork.ReviewsRatings.AddAsync(rating, cancellationToken);
                }
                else
                {
                    rating.Score = request.Score;
                }
            }

            // 3. Сохранение изменения оценки ReviewsRating
            // Это сохраняет новую/измененную запись ReviewsRating в БД.
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            // ПРИМЕЧАНИЕ: Теперь изменение оценки ГАРАНТИРОВАННО присутствует в БД.

            // 4. Атомарный пересчет счетчиков Review (выполняется на уровне БД)
            // Это решает проблему Lost Update.
            await _unitOfWork.Reviews.RecalculateRatingAsync(request.ReviewId, cancellationToken);

            // 5. ПЕРЕЗАГРУЗКА: Получение обновленных данных отзыва из БД
            // Поскольку RecalculateRatingAsync миновал ORM, нужно загрузить свежую сущность.
            // Используем FindAsync или GetByIdAsync. Если отзыв уже отслеживался (в шаге 1), 
            // его нужно явно перезагрузить или очистить отслеживание.
            _unitOfWork.Reviews.Detach(review);
            review = await _unitOfWork.Reviews.GetByIdAsync(request.ReviewId, cancellationToken);

            // Если GetByIdAsync возвращает null (что маловероятно), нужно обработать
            if (review == null) return null;

            // 6. Возврат DTO
            return new ReviewDetails
            {
                Id = review.Id,
                // Теперь эти значения АКТУАЛЬНЫ, так как review был получен заново из БД
                AverageRating = review.AverageRating,
                DislikesCount = review.DislikesCount,
                LikesCount = review.LikesCount,

                // Прочие свойства
                CreatedAt = review.CreatedAt,
                Score = review.Score,
                Text = review.Description,
                Title = review.Title,
                UserName = review.Name,
                UserVote = request.Score switch
                {
                    1 => true,
                    -1 => false,
                    _ => null
                }
            };
        }



    }
}
