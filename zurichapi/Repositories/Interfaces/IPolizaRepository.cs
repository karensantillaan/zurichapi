using zurichapi.Models;

namespace zurichapi.Repositories.Interfaces
{
    public interface IPolizaRepository
    {
        Task<List<Poliza>> GetAllAsync();
        Task<Poliza> GetByIdAsync(int id);
        Task<Poliza> CreateAsync(Poliza poliza);
        Task<Poliza> UpdateAsync(Poliza poliza);
        Task<bool> DeleteAsync(int id);
    }
}
