using backEnd.Context;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listPedidos = await _context.Pedido.ToListAsync();
                return Ok(listPedidos);
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
        public async Task<IActionResult> Post([FromBody] PedidoModel pedido)
        {
            try
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PedidoModel pedido)
        {
            try
            {
                if (id != pedido.ID)
                {
                    return NotFound();
                }

                _context.Update(pedido);
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
                var pedido = await _context.Pedido.FindAsync(id);

                if (pedido == null)
                {
                    return NotFound();
                }

                _context.Pedido.Remove(pedido);
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
