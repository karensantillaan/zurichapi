using zurichapi.Models;
using zurichapi.Repositories.Interfaces;
using zurichapi.Services.Interfaces;

namespace zurichapi.Services
{
    public class PolizaService : IPolizaService
    {
        private readonly IPolizaRepository _polizaRepository;
        private readonly IClienteRepository _clienteRepository;

        public PolizaService(IPolizaRepository polizaRepository, IClienteRepository clienteRepository)
        {
            _polizaRepository = polizaRepository;
            _clienteRepository = clienteRepository;
        }

        public Task<Poliza> CreatePolizaAsync(Poliza poliza) =>
            _polizaRepository.CreateAsync(poliza);

        public async Task<Poliza> CreatePolizaWithClientAsync(int clienteId, Poliza poliza)
        {
            var cliente = await _clienteRepository.GetByIdAsync(clienteId);
            if (cliente == null) throw new Exception("Cliente no encontrado");
            
            poliza.ClienteId = clienteId;
            return await _polizaRepository.CreateAsync(poliza);
        }

        public Task<bool> DeletePolizaAsync(int id) =>
            _polizaRepository.DeleteAsync(id);

        public Task<Poliza> GetPolizaByIdAsync(int id) =>
            _polizaRepository.GetByIdAsync(id);

        public Task<List<Poliza>> GetPolizasAsync() =>
            _polizaRepository.GetAllAsync();

        public Task<List<Poliza>> GetPolizasByClienteIdAsync(int clienteId) => 
            _polizaRepository.GetPolizasByClienteIdAsync(clienteId);

        public Task<Poliza> UpdatePolizaAsync(Poliza poliza) =>
            _polizaRepository.UpdateAsync(poliza);
    }
}
