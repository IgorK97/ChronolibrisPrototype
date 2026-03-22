using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models.Search
{
    public class LanguageDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CountryDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    // ── Роли персоналий ───────────────────────────────────────────────────────

    public class PersonRoleDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    // ── Персоналии (результат подсказки при вводе имени) ─────────────────────

    public class PersonSuggestionDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
    }

    // ── Теги (результат подсказки; всегда корневой тег) ──────────────────────

    public class TagSuggestionDto
    {
        public long Id { get; set; }
        /// <summary>Название корневого тега.</summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Название тега, который реально нашли по вводу пользователя.
        /// Если пользователь ввёл синоним — здесь будет имя синонима,
        /// чтобы UI мог показать "найдено через синоним «...»".
        /// </summary>
        public string? MatchedName { get; set; }
    }
}
