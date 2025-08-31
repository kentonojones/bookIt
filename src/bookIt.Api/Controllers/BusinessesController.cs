using bookIt.Infrastructure.Data;
using bookIt.Domain.Entities;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Business>>> GetBusinesses()
    {
        return await _context.Businesses.ToListAsync();
    }
}