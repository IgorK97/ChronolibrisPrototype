using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Interfaces;

namespace Chronolibris.Infrastructure.Files
{
    public class BookFileProvider : IBookFileProvider
    {
        private readonly string _booksDirectory;

        public BookFileProvider(string booksDirectory)
        {
            _booksDirectory = booksDirectory;
        }

        public async Task<byte[]> GetBookFileAsync(string fileName, CancellationToken cancellationToken = default)
        {
            var bookPath = Path.Combine(_booksDirectory, fileName);

            if (!File.Exists(bookPath))
                throw new FileNotFoundException("Book not found.", bookPath); //Или я лучше потом нуль верну?

            return await File.ReadAllBytesAsync(bookPath, cancellationToken);
        }

        //public async Task<Stream?> OpenReadStreamAsync(string fileName, CancellationToken token)
        //{
        //    var bookPath = Path.Combine(_booksDirectory, fileName);
        //    if (!File.Exists(bookPath))
        //        return null;

        //    return new FileStream(bookPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
        //}

        public async Task<Stream?> OpenReadStreamAsync(string fileName, CancellationToken token)
        {
            // 1. Убираем возможные "грязные" слеши и приводим к системному виду
            // Path.DirectorySeparatorChar в Windows это '\', в Linux '/'
            var safeRoot = _booksDirectory.Replace('/', Path.DirectorySeparatorChar)
                                          .Replace('\\', Path.DirectorySeparatorChar);

            var safeFileName = fileName.Replace('/', Path.DirectorySeparatorChar)
                                       .Replace('\\', Path.DirectorySeparatorChar);

            // 2. Если в fileName в начале есть слеш (например "/Buddism..."), 
            // Path.Combine может проигнорировать первую часть (root). Убираем начальный слеш.
            safeFileName = safeFileName.TrimStart(Path.DirectorySeparatorChar);

            // 3. Объединяем
            var bookPath = Path.Combine(safeRoot, safeFileName);

            // 4. (ВАЖНО) Логируем или смотрим в отладчике, что получилось!
            // Console.WriteLine($"Looking for file at: {bookPath}"); 

            if (!File.Exists(bookPath))
            {
                // Поставьте здесь точку останова (breakpoint) и посмотрите переменную bookPath
                return null;
            }

            //return new FileStream(bookPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
            return new FileStream(bookPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
        }
    }
}
