using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Domain.Models;
using Chronolibris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chronolibris.Infrastructure.DataAccess.Persistance.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly ApplicationDbContext _context;

        public TagsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<TagType>> GetTagTypesAsync(CancellationToken ct)
        {
            return await _context.TagTypes
                .OrderBy(t => t.Id)
                .ToListAsync(ct);
        }

        public async Task<List<TagDetails>> GetTagsAsync(
            long? tagTypeId,
    string? searchTerm,
    long? lastId,       // вместо page
    int limit,          // вместо pageSize
    CancellationToken ct)
        {
            IQueryable<Tag> query = _context.Tags.AsNoTracking()
    .Include(t => t.TagType);

            if (tagTypeId.HasValue)
                query = query.Where(t => t.TagTypeId == tagTypeId.Value);

            if (!string.IsNullOrWhiteSpace(searchTerm))
                query = query.Where(t => EF.Functions.Like(t.Name, $"%{searchTerm}%"));

            if (lastId.HasValue)
                query = query.Where(t => t.Id > lastId.Value);

            return await query
                .OrderBy(t => t.Id)        // сортировка по Id — обязательна для курсора
                .Take(limit + 1)           // берём +1 чтобы определить HasNext
                .Select(t => new TagDetails
                {
                    Id = t.Id,
                    Name = t.Name,
                    TagTypeId = t.TagTypeId,
                    TagTypeName = t.TagType.Name
                })
                .ToListAsync(ct);
        }

        public async Task<int> GetTagsCountAsync(
            long? tagTypeId,
            string? searchTerm,
            CancellationToken ct)
        {
            var query = _context.Tags.AsNoTracking();

            if (tagTypeId.HasValue)
            {
                query = query.Where(t => t.TagTypeId == tagTypeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(t => EF.Functions.Like(t.Name, $"%{searchTerm}%"));
            }

            return await query.CountAsync(ct);
        }
        public async Task<long> CreateAsync(Tag tag, CancellationToken ct)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync(ct);
            return tag.Id;
        }

        public async Task<bool> DeleteAsync(long tagId, CancellationToken ct)
        {
            var tag = await _context.Tags.FindAsync(new object[] { tagId }, ct);
            if (tag == null)
                return false;

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<Tag?> GetByIdAsync(long id, CancellationToken ct)
        {
            return await _context.Tags
                .Include(t => t.TagType)
                .FirstOrDefaultAsync(t => t.Id == id, ct);
        }
    }
}



