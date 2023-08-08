using Newtonsoft.Json;
using WebSite.Models;

namespace WebSite.Services
{
    public class PropertyService
    {
        private readonly HttpClient _httpClient;

        public PropertyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Property>> GetPropertiesAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7143/api/Property");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var properties = JsonConvert.DeserializeObject<List<Property>>(content);
                return properties;
            }

            return null;
        }
    }
}
