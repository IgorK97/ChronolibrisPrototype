using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReferencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получает полный справочник ролей участников (авторы, редакторы, переводчики и т.д.).
        /// </summary>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Список объектов RoleDetails.</returns>
        [HttpGet("roles")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RoleDetails>))]
        public async Task<ActionResult<IEnumerable<RoleDetails>>> GetPersonRoles()
        {
            var query = new GetRoleDetailsQuery();

            var roles = await _mediator.Send(query);

            return Ok(roles);
        }
    }
}
