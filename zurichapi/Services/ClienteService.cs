using zurichapi.Models;
using zurichapi.Repositories.Interfaces;
using zurichapi.Services.Interfaces;

namespace zurichapi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<Cliente> CreateClientAsync(Cliente cliente) =>
            _clienteRepository.CreateAsync(cliente);

        public Task<bool> DeleteClientAsync(int id) =>
            _clienteRepository.DeleteAsync(id);

        public Task<Cliente> GetClientByIdAsync(int id) =>
            _clienteRepository.GetByIdAsync(id);

        public Task<List<Cliente>> GetClientesAsync() => 
            _clienteRepository.GetAllAsync();

        public Task<Cliente> UpdateClientAsync(Cliente cliente) =>
            _clienteRepository.UpdateAsync(cliente);
    }
}
