using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetSelectionsQueryHandler(ISelectionsRepository selectionsRepository)
    : IRequestHandler<GetSelectionsQuery, IEnumerable<SelectionDetails>>
    {


        public async Task<IEnumerable<SelectionDetails>> Handle(GetSelectionsQuery request, CancellationToken ct)
        {
            var selections = await selectionsRepository.GetActiveSelectionsAsync(ct);

            return selections.Select(s => new SelectionDetails
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                //IsActive = s.IsActive
            });
        }
    }

}
