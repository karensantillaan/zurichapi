using zurichapi.Models;

namespace zurichapi.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClientByIdAsync(int id);
        Task<Cliente> CreateClientAsync(Cliente cliente);
        Task<Cliente> UpdateClientAsync(Cliente cliente);
        Task<bool> DeleteClientAsync(int id);
    }
}
