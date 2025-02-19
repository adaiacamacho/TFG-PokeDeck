using PokeDeck.ModelosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.Services
{
    public class CartaService
    {
        private readonly HttpClient _http;

        public CartaService(HttpClient http)
        {
            _http = http;
        }

        private string apiUrl = "https://localhost:7132/api/Cartas"; // Ajusta según tu API

        public async Task<List<CartaDB>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<CartaDB>>(apiUrl);
        }

        public async Task<CartaDB> GetById(int id)
        {
            return await _http.GetFromJsonAsync<CartaDB>($"{apiUrl}/{id}");
        }

        public async Task<bool> Add(CartaDB item)
        {
            var response = await _http.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, CartaDB item)
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
