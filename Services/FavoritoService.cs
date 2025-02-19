using PokeDeck.ModelosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.Services
{
    public class FavoritoService
    {
        private readonly HttpClient _http;

        public FavoritoService(HttpClient http)
        {
            _http = http;
        }

        private string apiUrl = "https://localhost:7132/api/Favoritoes"; // Ajusta según tu API

        public async Task<List<FavoritoDB>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<FavoritoDB>>(apiUrl);
        }

        public async Task<FavoritoDB> GetById(int id)
        {
            return await _http.GetFromJsonAsync<FavoritoDB>($"{apiUrl}/{id}");
        }

        public async Task<bool> Add(FavoritoDB item)
        {
            var response = await _http.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, FavoritoDB item)
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
