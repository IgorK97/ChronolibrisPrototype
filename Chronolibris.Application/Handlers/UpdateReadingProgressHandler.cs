using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class UpdatereadingProgressHandler(IUnitOfWork uow) : IRequestHandler<UpdateReadingProgressCommand, bool>
    {
        public async Task<bool> Handle(UpdateReadingProgressCommand command, CancellationToken token)
        {
            var readingProgress = await uow.ReadingProgresses.GetForBookUser(command.BookId, command.UserId);
            if(readingProgress is null)
            {
                var newReadingProgress = new ReadingProgress
                {
                    Id = 0,
                    BookId = command.BookId,
                    UserId = command.UserId,
                    Percentage = command.ReadingProgress,
                    ReadingDate = DateTime.UtcNow
                };
                await uow.ReadingProgresses.AddAsync(newReadingProgress);
                var result = await uow.SaveChangesAsync();
                if(result>0)
                    return true;
                return false;
            }

            if(readingProgress.Percentage < command.ReadingProgress)
            {
                readingProgress.Percentage = command.ReadingProgress;
                
            }
            readingProgress.ReadingDate = DateTime.UtcNow;
            uow.ReadingProgresses.Update(readingProgress);
            var res = await uow.SaveChangesAsync();
            if (res > 0)
                return true;
            return false;
        }
    }
}
