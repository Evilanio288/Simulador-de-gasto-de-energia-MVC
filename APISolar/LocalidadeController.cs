using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISolar.Data;
using APISolar.Models;

namespace APISolar
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadeController : ControllerBase
    {
        private readonly APISolarContext _context;

        public LocalidadeController(APISolarContext context)
        {
            _context = context;
        }

        // GET: api/Localidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalidadeModel>>> GetLocalidadeModel()
        {
            return await _context.LocalidadeModel.ToListAsync();
        }

        // GET: api/Localidade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalidadeModel>> GetLocalidadeModel(int id)
        {
            var localidadeModel = await _context.LocalidadeModel.FindAsync(id);

            if (localidadeModel == null)
            {
                return NotFound();
            }

            return localidadeModel;
        }

        // PUT: api/Localidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidadeModel(int id, LocalidadeModel localidadeModel)
        {
            if (id != localidadeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(localidadeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadeModelExists(id))
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

        // POST: api/Localidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocalidadeModel>> PostLocalidadeModel(LocalidadeModel localidadeModel)
        {
            _context.LocalidadeModel.Add(localidadeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalidadeModel", new { id = localidadeModel.Id }, localidadeModel);
        }

        // DELETE: api/Localidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidadeModel(int id)
        {
            var localidadeModel = await _context.LocalidadeModel.FindAsync(id);
            if (localidadeModel == null)
            {
                return NotFound();
            }

            _context.LocalidadeModel.Remove(localidadeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalidadeModelExists(int id)
        {
            return _context.LocalidadeModel.Any(e => e.Id == id);
        }
    }
}
