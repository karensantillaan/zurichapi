using Microsoft.EntityFrameworkCore;
using zurichapi.Data;
using zurichapi.Models;
using zurichapi.Repositories.Interfaces;

namespace zurichapi.Repositories
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly AppDbContext _context;

        public PolizaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Poliza> CreateAsync(Poliza poliza)
        {
            _context.Polizas.Add(poliza);
            await _context.SaveChangesAsync();
            return poliza;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var poliza = await _context.Polizas.FindAsync(id);
            if (poliza == null) return false; // Poliza not found

            _context.Polizas.Remove(poliza);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Poliza>> GetAllAsync() => 
            await _context.Polizas.Include(p => p.Cliente).ToListAsync();

        public async Task<Poliza> GetByIdAsync(int id) => 
            await _context.Polizas.Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new KeyNotFoundException($"Poliza with ID {id} not found.");

        public async Task<List<Poliza>> GetPolizasByClienteIdAsync(int clienteId)
        {
            return await _context.Polizas
                .Where(p => p.ClienteId == clienteId)
                .Include(p => p.Cliente)
                .ToListAsync();
        }

        public async Task<Poliza> UpdateAsync(Poliza poliza)
        {
            _context.Polizas.Update(poliza);
            await _context.SaveChangesAsync();
            return poliza;
        }
    }
}
