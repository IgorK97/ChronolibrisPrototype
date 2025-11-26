using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Domain.Models;
using MediatR;

namespace Chronolibris.Application.Handlers
{
    public class GetReadBooksHandler(IReadingProgressRepository readingProgressRepository) 
        : IRequestHandler<GetReadBooksQuery, PagedResult<BookListItem>>
    {
        public async Task<PagedResult<BookListItem>> Handle(GetReadBooksQuery query, CancellationToken token)
        {
            var books = await readingProgressRepository.GetBooks(query.UserId, query.LastId, query.Limit + 1, token);

            bool hasNext = books.Count > query.Limit;

            if (hasNext)
            {
                // Удаляем лишний элемент, который брали для проверки
                books.RemoveAt(books.Count - 1);
            }

            return new PagedResult<BookListItem>
            {
                Items = books,
                Limit = query.Limit,
                HasNext = hasNext,
                LastId = books.LastOrDefault()?.Id
            };
        }
    }
}
