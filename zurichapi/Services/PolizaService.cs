using zurichapi.Models;
using zurichapi.Repositories.Interfaces;
using zurichapi.Services.Interfaces;

namespace zurichapi.Services
{
    public class PolizaService : IPolizaService
    {
        private readonly IPolizaRepository _polizaRepository;

        public PolizaService(IPolizaRepository polizaRepository)
        {
            _polizaRepository = polizaRepository;
        }

        public Task<Poliza> CreatePolizaAsync(Poliza poliza) =>
            _polizaRepository.CreateAsync(poliza);

        public Task<bool> DeletePolizaAsync(int id) =>
            _polizaRepository.DeleteAsync(id);

        public Task<Poliza> GetPolizaByIdAsync(int id) =>
            _polizaRepository.GetByIdAsync(id);

        public Task<List<Poliza>> GetPolizasAsync() =>
            _polizaRepository.GetAllAsync();

        public Task<Poliza> UpdatePolizaAsync(Poliza poliza) =>
            _polizaRepository.UpdateAsync(poliza);
    }
}
