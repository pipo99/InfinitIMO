﻿using Newtonsoft.Json;
using System.Text;
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
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7143/api/Property/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var property = JsonConvert.DeserializeObject<Property>(content);
                return property;
            }

            return null;
        }

        public async Task<bool> Create(Property property)
        {
            var serializedProperty = JsonConvert.SerializeObject(property);
            var content = new StringContent(serializedProperty, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7143/api/Property", content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;

            //TODO: Colocar a devolver uma estrutura de response (code; message)
        }

    }
}
