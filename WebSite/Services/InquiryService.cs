using Newtonsoft.Json;
using System.Text;
using WebSite.Models;

namespace WebSite.Services
{
    public class InquiryService
    {
        // TODO: METER URL API POR DEFINICAO 

        private readonly HttpClient _httpClient;

        public InquiryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Inquiry>> GetInquiriesAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7041/api/Inquiry");

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
            var response = await _httpClient.GetAsync($"https://localhost:7041/api/Inquiry/{id}");

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

            var response = await _httpClient.PostAsync("https://localhost:7041/api/Inquiry", content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;

            //TODO: Colocar a devolver uma estrutura de response (code; message)
        }

    }
}
