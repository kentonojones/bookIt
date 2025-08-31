using bookIt.Application.Dtos;
using bookIt.Domain.Entities;
using bookIt.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BusinessesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/businesses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Business>>> GetBusinesses()
    {
        return await _context.Businesses.ToListAsync();
    }

    // GET: api/businesses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Business>> GetBusiness(int id)
    {
        var business = await _context.Businesses.FindAsync(id);
        if (business == null)
        {
            return NotFound();
        }
        return business;
    }

    // POST: api/businesses
    [HttpPost]
    public async Task<ActionResult<Business>> PostBusiness(CreateBusinessDto createBusinessDto)
    {
        var business = new Business
        {
            Name = createBusinessDto.Name,
            OwnerId = createBusinessDto.OwnerId
        };

        _context.Businesses.Add(business);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBusiness), new { id = business.Id }, business);
    }

    // PUT: api/businesses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBusiness(int id, UpdateBusinessDto updateBusinessDto)
    {
        var business = await _context.Businesses.FindAsync(id);

        if (business == null)
        {
            return NotFound();
        }

        business.Name = updateBusinessDto.Name;
        _context.Entry(business).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/businesses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusiness(int id)
    {
        var business = await _context.Businesses.FindAsync(id);
        if (business == null)
        {
            return NotFound();
        }

        business.IsDeleted = true;
        _context.Entry(business).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
