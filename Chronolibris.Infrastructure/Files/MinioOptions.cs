using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Infrastructure.DataAccess.Files
{
    /// <summary>
    /// Параметры подключения к MinIO.
    /// Секция в appsettings.json: <c>MinioOptions</c>.
    /// </summary>
    public sealed class MinioOptions
    {
        public string Endpoint { get; set; } = "localhost:9000";
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public bool UseSSL { get; set; } = false;
    }

    /// <summary>
    /// Параметры хранилища книг.
    /// Секция в appsettings.json: <c>BookStorageOptions</c>.
    /// </summary>
    public sealed class BookStorageOptions
    {
        /// <summary>Бакет для хранения книг.</summary>
        public string BooksBucket { get; set; } = "books";

        /// <summary>Версионный префикс пути внутри бакета: <c>v1/{bookId}/...</c></summary>
        public string Prefix { get; set; } = "v1";
    }

    /// <summary>
    /// Параметры хранилища пользовательских загрузок.
    /// Секция в appsettings.json: <c>MinioOptions</c> (поле <c>BucketName</c>).
    /// </summary>
    public sealed class UploadStorageOptions
    {
        /// <summary>Бакет для обложек и прочих пользовательских файлов.</summary>
        public string UploadsBucket { get; set; } = "pcovers";
    }
}
