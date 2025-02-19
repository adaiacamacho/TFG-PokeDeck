using PokeDeck.ModelosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.Services
{
    public class IdiomaService
    {
        private readonly HttpClient _http;

        public IdiomaService(HttpClient http)
        {
            _http = http;
        }

        private string apiUrl = "https://localhost:7132/api/Idiomas"; // Ajusta según tu API

        public async Task<List<IdiomaDB>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<IdiomaDB>>(apiUrl);
        }

        public async Task<IdiomaDB> GetById(int id)
        {
            return await _http.GetFromJsonAsync<IdiomaDB>($"{apiUrl}/{id}");
        }

        public async Task<bool> Add(IdiomaDB item)
        {
            var response = await _http.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, IdiomaDB item)
        {
            var response = await _http.PutAsJsonAsync($"{apiUrl}/{id}", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"{apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
