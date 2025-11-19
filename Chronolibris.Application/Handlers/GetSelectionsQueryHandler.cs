using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.DTOs;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetSelectionsQueryHandler
    : IRequestHandler<GetSelectionsQuery, IEnumerable<SelectionDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetSelectionsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<SelectionDto>> Handle(GetSelectionsQuery request, CancellationToken ct)
        {
            var selections = await _uow.Selections.GetActiveSelectionsAsync();

            return selections.Select(s => new SelectionDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                //IsActive = s.IsActive
            });
        }
    }

}
