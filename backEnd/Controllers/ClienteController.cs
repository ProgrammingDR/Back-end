using backEnd.Context;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClienteController(ApplicationDbContext context) 
        {
            _context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listClientes = await _context.Cliente.ToListAsync();
                return Ok(listClientes);
            }
            catch(Exception ex)
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
        public async Task<IActionResult>  Post([FromBody] ClienteModel cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteModel cliente)
        {
            try
            {
                if(id != cliente.ID)
                {
                    return NotFound();
                }

                _context.Update(cliente);
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
                var cliente = await _context.Cliente.FindAsync(id);

                if(cliente == null)
                {
                    return NotFound();
                }

                _context.Cliente.Remove(cliente);
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
