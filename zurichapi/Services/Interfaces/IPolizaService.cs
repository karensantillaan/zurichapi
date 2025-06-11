using zurichapi.Models;

namespace zurichapi.Services.Interfaces
{
    public interface IPolizaService
    {
        Task<List<Poliza>> GetPolizasAsync();
        Task<Poliza> GetPolizaByIdAsync(int id);
        Task<Poliza> CreatePolizaAsync(Poliza poliza);
        Task<Poliza> UpdatePolizaAsync(Poliza poliza);
        Task<bool> DeletePolizaAsync(int id);
        Task<List<Poliza>> GetPolizasByClienteIdAsync(int clienteId);
        Task<Poliza> CreatePolizaWithClientAsync(int clienteId, Poliza poliza);
    }
}
