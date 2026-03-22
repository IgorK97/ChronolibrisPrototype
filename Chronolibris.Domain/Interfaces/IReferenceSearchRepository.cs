using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Models.Search;

namespace Chronolibris.Domain.Interfaces
{
    public interface IReferenceSearchRepository
    {
        /// <summary>Все языки — для списка с прокруткой.</summary>
        Task<List<LanguageDto>> GetAllLanguagesAsync(CancellationToken ct = default);

        /// <summary>Все страны — для списка с прокруткой.</summary>
        Task<List<CountryDto>> GetAllCountriesAsync(CancellationToken ct = default);

        /// <summary>Все роли персоналий.</summary>
        Task<List<PersonRoleDto>> GetAllPersonRolesAsync(CancellationToken ct = default);

        /// <summary>
        /// Поиск персоналий по имени (ILIKE). Возвращает не более <paramref name="limit"/> результатов.
        /// </summary>
        Task<List<PersonSuggestionDto>> SearchPersonsAsync(
            string name, int limit = 10, CancellationToken ct = default);

        /// <summary>
        /// Поиск тега по имени (ILIKE).
        /// Если найденный тег является синонимом (RelationTypeId = 1),
        /// возвращает его корневой тег вместо него самого.
        /// MatchedName содержит имя реально найденного тега (синонима или самого тега).
        /// </summary>
        Task<List<TagSuggestionDto>> SearchTagsAsync(
            string name, int limit = 10, CancellationToken ct = default);
    }

}
