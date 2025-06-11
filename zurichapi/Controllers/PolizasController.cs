using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zurichapi.Models;
using zurichapi.Services.Interfaces;

namespace zurichapi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaService _polizaService;

        public PolizasController(IPolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPolizas() =>
            Ok(await _polizaService.GetPolizasAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPolizaById(int id)
        {
            var poliza = await _polizaService.GetPolizaByIdAsync(id);
            return poliza == null ? NotFound() : Ok(poliza);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePoliza([FromBody] Poliza poliza)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newPoliza = await _polizaService.CreatePolizaAsync(poliza);
            return CreatedAtAction(nameof(GetPolizaById), new { id = newPoliza.Id }, newPoliza);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePoliza(int id, [FromBody] Poliza poliza)
        {
            if (id != poliza.Id || !ModelState.IsValid) return BadRequest(ModelState);
            var updatedPoliza = await _polizaService.UpdatePolizaAsync(poliza);
            return Ok(updatedPoliza);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePoliza(int id)
        {
            var deleted = await _polizaService.DeletePolizaAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
