using Model.Dto;
using System.Net.Http;
using System.Net.Http.Json;

namespace Client.Services
{
    class SiteService
    {
        private HttpClient _httpClient;

        public SiteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SiteDto>> GetSites()
        {
            try
            {
                IEnumerable<SiteDto>? response = await _httpClient.GetFromJsonAsync<IEnumerable<SiteDto>>("api/sites");
                return response ?? Enumerable.Empty<SiteDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'appel API : {ex.Message}");
                throw;
            }
        }
    }
}
