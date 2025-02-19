
using PokeDeck.ModelosBD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        private string apiUrl = "https://localhost:7132/api/Usuarios"; // Ajusta según tu API

        public async Task<List<UsuarioDB>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<UsuarioDB>>(apiUrl);
        }

        public async Task<UsuarioDB> GetById(int id)
        {
            return await _http.GetFromJsonAsync<UsuarioDB>($"{apiUrl}/{id}");
        }

        public async Task<bool> Add(UsuarioDB item)
        {
            var response = await _http.PostAsJsonAsync(apiUrl, item);
            string body=await response.Content.ReadAsStringAsync();
            Debug.WriteLine(body);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, UsuarioDB item)
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
