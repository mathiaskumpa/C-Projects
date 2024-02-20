using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDB.Data;
using MovieDB.Models;

namespace MovieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionCompaniesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public ProductionCompaniesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductionCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionCompany>>> GetProductionCompanies()
        {
            return await _context.ProductionCompanies.ToListAsync();
        }

        // GET: api/ProductionCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionCompany>> GetProductionCompany(int id)
        {
            var productionCompany = await _context.ProductionCompanies.FindAsync(id);

            if (productionCompany == null)
            {
                return NotFound();
            }

            return productionCompany;
        }

        // POST: api/ProductionCompanies
        [HttpPost]
        public async Task<ActionResult<ProductionCompany>> PostProductionCompany(ProductionCompany productionCompany)
        {
            _context.ProductionCompanies.Add(productionCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionCompany", new { id = productionCompany.CompanyID }, productionCompany);
        }

        // PUT: api/ProductionCompanies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionCompany(int id, ProductionCompany productionCompany)
        {
            if (id != productionCompany.CompanyID)
            {
                return BadRequest();
            }

            _context.Entry(productionCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionCompanyExists(id))
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

        // DELETE: api/ProductionCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionCompany(int id)
        {
            var productionCompany = await _context.ProductionCompanies.FindAsync(id);
            if (productionCompany == null)
            {
                return NotFound();
            }

            _context.ProductionCompanies.Remove(productionCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductionCompanyExists(int id)
        {
            return _context.ProductionCompanies.Any(e => e.CompanyID == id);
        }
    }
}
