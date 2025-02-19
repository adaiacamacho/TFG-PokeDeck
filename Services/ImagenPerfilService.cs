using PokeDeck.ModelosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.Services
{
    public class ImagenPerfilService
    {
        private readonly HttpClient _http;

        public ImagenPerfilService(HttpClient http)
        {
            _http = http;
        }

        private string apiUrl = "https://localhost:7132/api/ImagenPerfils"; // Ajusta según tu API

        public async Task<List<ImagenPerfilDB>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<ImagenPerfilDB>>(apiUrl);
        }

        public async Task<ImagenPerfilDB> GetById(int id)
        {
            return await _http.GetFromJsonAsync<ImagenPerfilDB>($"{apiUrl}/{id}");
        }

        public async Task<bool> Add(ImagenPerfilDB item)
        {
            var response = await _http.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, ImagenPerfilDB item)
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
