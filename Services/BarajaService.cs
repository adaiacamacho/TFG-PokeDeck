using PokeDeck.ModelosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokeDeck.Services
{
    public class BarajaService
    {
        private readonly HttpClient _http;

        public BarajaService(HttpClient http)
        {
            _http = http;
        }

        private string apiUrl = "https://localhost:7132/api/Barajas"; // Ajusta según tu API

        public async Task<List<BarajaDB>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<BarajaDB>>(apiUrl);
        }

        //obtener barajas en base al id del user logeado
        public async Task<List<BarajaDB>> GetByUserId(int userId)
        {
            return await _http.GetFromJsonAsync<List<BarajaDB>>($"{apiUrl}/usuario/{userId}");
        }


        public async Task<BarajaDB> GetById(int id)
        {
            return await _http.GetFromJsonAsync<BarajaDB>($"{apiUrl}/{id}");
        }

        public async Task<bool> Add(BarajaDB item)
        {
            var response = await _http.PostAsJsonAsync(apiUrl, item);
            return response.IsSuccessStatusCode;
        }

        //editar
        public async Task<bool> Update(int id, BarajaDB item)
        {
            var response = await _http.PutAsJsonAsync($"{apiUrl}/{id}", item);
            return response.IsSuccessStatusCode;
        }

        //eliminar
        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"{apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
