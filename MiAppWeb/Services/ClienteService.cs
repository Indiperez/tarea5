namespace MiAppWeb.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MiAppWeb.Models;

    public class ClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Cliente>>("https://localhost:7110/api/Clientes");
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Cliente>($"https://localhost:7110/api/Clientes/{id}");
        }

        public async Task CreateClienteAsync(Cliente cliente)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7110/api/Clientes", cliente);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7110/api/Clientes/{cliente.Id}", cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7110/api/Clientes/{id}");
        }
    }

}
