using backEnd.Context;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listVentas = await _context.Venta.ToListAsync();
                return Ok(listVentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VentaModel venta)
        {
            try
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return Ok(venta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VentaModel venta)
        {
            try
            {
                if (id != venta.ID)
                {
                    return NotFound();
                }

                _context.Update(venta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El registro fue actualizado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var venta = await _context.Venta.FindAsync(id);

                if (venta == null)
                {
                    return NotFound();
                }

                _context.Venta.Remove(venta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Registro eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
