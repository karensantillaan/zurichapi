using Microsoft.EntityFrameworkCore;
using zurichapi.Data;
using zurichapi.Models;
using zurichapi.Repositories.Interfaces;

namespace zurichapi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false; // Cliente not found
            
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> GetAllAsync() => 
            await _context.Clientes.Include(c => c.Polizas).ToListAsync();

        public async Task<Cliente> GetByIdAsync(int id) => 
            await _context.Clientes.Include(c => c.Polizas)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new KeyNotFoundException($"Cliente with ID {id} not found.");

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
