using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiHw.Data;
using WepApiHw.Models;

namespace WepApiHw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class aspirantesController : ControllerBase
    {
        private readonly WepApiHwContext _context;

        public aspirantesController(WepApiHwContext context)
        {
            _context = context;
        }

        // GET: api/aspirantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<aspirantes>>> Getaspirantes()
        {
            return await _context.aspirantes.ToListAsync();
        }

        // GET: api/aspirantes/5 opcion para leer recibe como parametro el id
        [HttpGet("{id}")]
        public async Task<ActionResult<aspirantes>> Getaspirantes(int id)
        {
            var aspirantes = await _context.aspirantes.FindAsync(id);

            if (aspirantes == null)
            {
                return NotFound();
            }

            return aspirantes;
        }

        // PUT: api/aspirantes/5 opcion para modificar recibe como parametro el id
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaspirantes(int id, aspirantes aspirantes)
        {
            if (id != aspirantes.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspirantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspirantesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/aspirantes opcion para insertar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<aspirantes>> Postaspirantes(aspirantes aspirantes)
        {
            _context.aspirantes.Add(aspirantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaspirantes", new { id = aspirantes.Id }, aspirantes);
        }

        // DELETE: api/aspirantes/5 opcion para eliminar recibe como parametro el id
        [HttpDelete("{id}")]
        public async Task<ActionResult<aspirantes>> Deleteaspirantes(int id)
        {
            var aspirantes = await _context.aspirantes.FindAsync(id);
            if (aspirantes == null)
            {
                return NotFound();
            }

            _context.aspirantes.Remove(aspirantes);
            await _context.SaveChangesAsync();

            return aspirantes;
        }

        //clase de verificacion que recibe como parametro el id
        private bool aspirantesExists(int id)
        {
            return _context.aspirantes.Any(e => e.Id == id);
        }
    }
}
