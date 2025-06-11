using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zurichapi.Models;
using zurichapi.Services.Interfaces;

namespace zurichapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IPolizaService _polizaService;

        public ClientesController(IClienteService clienteService, IPolizaService polizaService)
        {
            _clienteService = clienteService;
            _polizaService = polizaService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetClientes() =>
            Ok(await _clienteService.GetClientesAsync());


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClientByIdAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newClient = await _clienteService.CreateClientAsync(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = newClient.Id }, newClient);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id || !ModelState.IsValid) return BadRequest(ModelState);

            var updatedClient = await _clienteService.UpdateClientAsync(cliente);
            return Ok(updatedClient);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var deleted = await _clienteService.DeleteClientAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("{clienteId:int}/polizas")]
        public async Task<IActionResult> GetPolizasByClienteId(int clienteId)
        {
            var polizas = await _polizaService.GetPolizasByClienteIdAsync(clienteId);
            if (!polizas.Any()) return NotFound("El cliente no tiene pólizas.");
            return Ok(polizas);
        }
    }
}
