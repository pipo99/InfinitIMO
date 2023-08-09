using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using WebSite.Models;

namespace WebSite.Services
{
    public class InquiryService
    {
        private readonly ApiSettings _apiSettings;
        private readonly HttpClient _httpClient;

        public InquiryService(IConfiguration configuration, HttpClient httpClient)
        {
            _apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            _httpClient = httpClient;
        }

        public async Task<List<Inquiry>> GetInquiriesAsync()
        {
            var apiUrl = $"{_apiSettings.InquiryAPIURL}/api/Inquiry";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var inquiries = JsonConvert.DeserializeObject<List<Inquiry>>(content);
                return inquiries;
            }

            return null;
        }
        public async Task<Inquiry> GetInquiryByIdAsync(int id)
        {
            var apiUrl = $"{_apiSettings.InquiryAPIURL}/api/Inquiry/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var inquiry = JsonConvert.DeserializeObject<Inquiry>(content);
                return inquiry;
            }

            return null;
        }

        public async Task<bool> Create(Inquiry inquiry)
        {
            var serializedInquiry = JsonConvert.SerializeObject(inquiry);
            var content = new StringContent(serializedInquiry, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiSettings.InquiryAPIURL}/api/Inquiry", content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

    }
}
