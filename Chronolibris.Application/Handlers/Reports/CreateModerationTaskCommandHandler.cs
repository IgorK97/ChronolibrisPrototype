using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Requests.Reports;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Exceptions;
using Chronolibris.Domain.Interfaces.Repository;
using Chronolibris.Domain.Models;
using MediatR;

namespace Chronolibris.Application.Handlers.Reports
{
    public class CreateModerationTaskCommandHandler
        :IRequestHandler<CreateModerationTaskCommand, CreateModerationTaskResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModerationTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateModerationTaskResponse> Handle(
            CreateModerationTaskCommand request, CancellationToken token)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var lastTask = await _unitOfWork.ModerationTasks.GetLastTaskAsync(request.TargetId, request.TargetTypeId, token);

                if (lastTask != null && lastTask.StatusId == 2)
                {
                    throw new ChronolibrisException("Для данного контента уже существует активная задача модерации", ErrorType.Conflict);
                }

                var checkNumber = (lastTask?.CheckNumber ?? -1) + 1;

                var newTask = new ModerationTask
                {
                    TargetId = request.TargetId,
                    TargetTypeId = request.TargetTypeId,
                    ModeratedBy = request.ModeratorId,
                    StartedAt = DateTime.UtcNow,
                    StatusId = 2,
                    Comment = "",
                    CheckNumber = checkNumber,
                    ReasonTypeId = request.ReportTypeId,
                };

                await _unitOfWork.ModerationTasks.AddAsync(newTask, token);
                await _unitOfWork.SaveChangesAsync(token);

                await _unitOfWork.Reports.AttachReportsToTaskAsync(
                    newTask.Id,
                    request.TargetId,
                    request.TargetTypeId,
                    request.ReportTypeId,
                    token);

                await transaction.CommitAsync(token);

                return new CreateModerationTaskResponse
                {
                    Id = newTask.Id,
                    TaskCreatedAt = newTask.StartedAt,
                    TaskStatusId = newTask.StatusId,
                };




                //var task = await _unitOfWork.Reports.CreateModerationTaskWithReportsAsync(
                //    request.TargetId,
                //    request.TargetTypeId,
                //    request.ReportTypeId,
                //    request.ModeratorId,
                //    transaction);
                //await _unitOfWork.SaveChangesAsync(token);
                //await transaction.CommitAsync(token);
                //return new CreateModerationTaskResponse
                //{
                //    Id = task.Id,
                //    TaskCreatedAt = task.StartedAt,
                //    TaskStatusId = task.StatusId,
                //};
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
    }

}
