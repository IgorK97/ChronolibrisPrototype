// File: Chronolibris.Domain.Interfaces.IThemeRepository.cs
using Chronolibris.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Interfaces
{
    public interface IThemeRepository
    {
        Task<Theme?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Theme>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Theme>> GetByParentIdAsync(long? parentThemeId, CancellationToken cancellationToken = default);
        Task AddAsync(Theme theme, CancellationToken cancellationToken = default);
        void Update(Theme theme);
        void Delete(Theme theme);
        Task<int> GetSubThemesCountAsync(long themeId, CancellationToken cancellationToken = default);
        Task<bool> HasSubThemesAsync(long themeId, CancellationToken cancellationToken = default);
    }
}