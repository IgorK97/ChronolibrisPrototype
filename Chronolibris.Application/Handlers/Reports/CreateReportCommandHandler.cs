using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Chronolibris.Application.Requests.Reports;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Exceptions;
using Chronolibris.Domain.Interfaces.Repository;
using Chronolibris.Domain.Options;
using FluentValidation;
using MediatR;

namespace Chronolibris.Application.Handlers.Reports
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreateReportResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReportingOptions _options;

        public CreateReportCommandHandler(
            IUnitOfWork unitOfWork,
            ReportingOptions options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<CreateReportResult> Handle(
            CreateReportCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;

            var cooldownThreshold = now - _options.ReportCooldown;

            var isOnCooldown = await _unitOfWork.Reports.GetLastUserReport(request.UserId,
                request.TargetTypeId, request.TargetId, request.ReasonTypeId);
            //можно добавить atomic cooldown insert,
            //если окажется, что среднее количество ожидаемых получаемых жалоб
            //будет слишком высоко, а так можно пока так оставить
            //(в конце концов у меня еще клиент задержимает, поэтому технически будет сложно это сделать,
            //но если такое действительно будет случаться часть - тогда да, это проблема)
            if (isOnCooldown is not null && isOnCooldown.CreatedAt >= cooldownThreshold)
                throw new ChronolibrisException($"Вы уже отправляли подобную жалобу. Жалобы одного типа можно отправлять" +
                    $"не ранее, чем через {_options.ReportCooldown.TotalDays} дн.", ErrorType.TooManyRequests);

            var activeTask = await _unitOfWork.ModerationTasks.GetActiveByTarget(request.TargetId,
                request.TargetTypeId);

            var report = new Report
            {
                TargetId = request.TargetId,
                TargetTypeId = request.TargetTypeId,
                ReasonTypeId = request.ReasonTypeId,
                Description = request.Description,
                CreatedBy = request.UserId,
                CreatedAt = now,
                ModerationTaskId = activeTask?.Id ?? null,
            };

            await _unitOfWork.Reports.AddAsync(report);
            await _unitOfWork.SaveChangesAsync();
            return new CreateReportResult(true, null);
        }
    }

}
