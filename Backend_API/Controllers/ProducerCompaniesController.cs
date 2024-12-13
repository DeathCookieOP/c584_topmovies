using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataModel;
using Backend_API.DTO;

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerCompaniesController : ControllerBase
    {
        private readonly RonnyMoviesContext _context;

        public ProducerCompaniesController(RonnyMoviesContext context)
        {
            _context = context;
        }

        // GET: api/ProducerCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProducerCompany>>> GetProducerCompanies()
        {
            return await _context.ProducerCompanies.ToListAsync();
        }

        // GET: api/ProducerCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProducerCompany>> GetProducerCompany(int id)
        {
            var producerCompany = await _context.ProducerCompanies.FindAsync(id);

            if (producerCompany == null)
            {
                return NotFound();
            }

            return producerCompany;
        }

        // PUT: api/ProducerCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducerCompany(int id, ProducerCompany producerCompany)
        {
            if (id != producerCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(producerCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducerCompanyExists(id))
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

        // POST: api/ProducerCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProducerCompany>> PostProducerCompany(CompanyAddDTO companyDTO)
        {
            var producerCompany = new ProducerCompany
            {
                CompanyImage = companyDTO.CompanyImage,
                Name = companyDTO.Name,
                Description = companyDTO.Description,
                FoundedYear = companyDTO.FoundedYear
            };

            _context.ProducerCompanies.Add(producerCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducerCompany", new { id = producerCompany.Id }, producerCompany);
        }

        // DELETE: api/ProducerCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducerCompany(int id)
        {
            var producerCompany = await _context.ProducerCompanies.FindAsync(id);
            if (producerCompany == null)
            {
                return NotFound();
            }

            _context.ProducerCompanies.Remove(producerCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProducerCompanyExists(int id)
        {
            return _context.ProducerCompanies.Any(e => e.Id == id);
        }
    }
}
