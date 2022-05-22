using backEnd.Context;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEmpleado = await _context.Empleado.ToListAsync();
                return Ok(listEmpleado);
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
        public async Task<IActionResult> Post([FromBody] EmpleadoModel empleado)
        {
            try
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmpleadoModel empleado)
        {
            try
            {
                if (id != empleado.ID)
                {
                    return NotFound();
                }

                _context.Update(empleado);
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
                var empleado = await _context.Empleado.FindAsync(id);

                if (empleado == null)
                {
                    return NotFound();
                }

                _context.Empleado.Remove(empleado);
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
