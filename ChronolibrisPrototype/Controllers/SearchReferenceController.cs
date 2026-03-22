using Chronolibris.Application.Search;
using Chronolibris.Application.Search.Queries;
using Chronolibris.Domain.Models.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chronolibris.API.Controllers.Search
{
    /// <summary>
    /// Справочные данные для панели расширенного поиска.
    /// Все методы публичные — авторизация не нужна.
    /// </summary>
    [ApiController]
    [Route("api/search/reference")]
    public class SearchReferenceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SearchReferenceController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// GET /api/search/reference/languages
        /// Полный список языков для мультиселекта.
        /// </summary>
        [HttpGet("languages")]
        [ProducesResponseType(typeof(List<LanguageDto>), 200)]
        public Task<List<LanguageDto>> GetLanguages(CancellationToken ct)
            => _mediator.Send(new GetLanguagesQuery(), ct);

        /// <summary>
        /// GET /api/search/reference/countries
        /// Полный список стран для мультиселекта.
        /// </summary>
        [HttpGet("countries")]
        [ProducesResponseType(typeof(List<CountryDto>), 200)]
        public Task<List<CountryDto>> GetCountries(CancellationToken ct)
            => _mediator.Send(new GetCountriesQuery(), ct);

        /// <summary>
        /// GET /api/search/reference/person-roles
        /// Все роли персоналий.
        /// </summary>
        [HttpGet("person-roles")]
        [ProducesResponseType(typeof(List<PersonRoleDto>), 200)]
        public Task<List<PersonRoleDto>> GetPersonRoles(CancellationToken ct)
            => _mediator.Send(new GetPersonRolesQuery(), ct);

        /// <summary>
        /// GET /api/search/reference/persons?name=толст&amp;limit=10
        /// Подсказки персоналий по введённому имени (ILIKE).
        /// </summary>
        [HttpGet("persons")]
        [ProducesResponseType(typeof(List<PersonSuggestionDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<PersonSuggestionDto>>> SearchPersons(
            [FromQuery] string name,
            [FromQuery] int limit = 10,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Параметр name обязателен.");

            if (limit is < 1 or > 50)
                return BadRequest("limit должен быть от 1 до 50.");

            return await _mediator.Send(new SearchPersonsQuery(name, limit), ct);
        }

        /// <summary>
        /// GET /api/search/reference/tags?name=мисти&amp;limit=10
        /// Подсказки тегов. Если введённое слово совпадает с синонимом,
        /// возвращается корневой тег; MatchedName содержит найденный синоним.
        /// </summary>
        [HttpGet("tags")]
        [ProducesResponseType(typeof(List<TagSuggestionDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<TagSuggestionDto>>> SearchTags(
            [FromQuery] string name,
            [FromQuery] int limit = 10,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Параметр name обязателен.");

            if (limit is < 1 or > 50)
                return BadRequest("limit должен быть от 1 до 50.");

            return await _mediator.Send(new SearchTagsQuery(name, limit), ct);
        }
    }
}
