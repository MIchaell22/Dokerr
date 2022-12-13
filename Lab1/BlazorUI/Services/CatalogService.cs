using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorUI.Models;
using BlazorUI.Interfaces.IServices;

namespace BlazorUI.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CatalogViewModel>> GetCatalogsAsync()
        {
            var response = await _httpClient.GetAsync("catalog");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<CatalogViewModel>>(responseContent);
        }

        public async Task<CatalogViewModel> GetCatalogById(int CatalogId)
        {
            var response = await _httpClient.GetAsync($"catalog/{CatalogId}");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<CatalogViewModel>(responseContent);
        }
    }
}
