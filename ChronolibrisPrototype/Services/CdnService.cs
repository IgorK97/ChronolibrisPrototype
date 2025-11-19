using Chronolibris.Application.Interfaces;

namespace ChronolibrisPrototype.Services
{
    public class CdnService : ICdnService
    {
        private readonly string _baseUrl;

        public CdnService(IConfiguration configuration)
        {
            _baseUrl = configuration["CdnBaseUrl"] ?? throw new ArgumentNullException("CdnBaseUrl");
        }

        public string GetCoverUrl(string coverPath)
        {
            if (string.IsNullOrEmpty(coverPath)) return null!;
            return $"{_baseUrl}{coverPath}";
        }
    }

}
