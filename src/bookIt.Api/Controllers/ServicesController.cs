using bookIt.Application.Dtos;
using bookIt.Domain.Entities;
using bookIt.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // Secure this entire controller
public class ServicesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServicesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/services?businessId=1
    [HttpGet]
    [AllowAnonymous] // Anyone can view services
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices([FromQuery] int businessId)
    {
        return await _context.Services
            .Include(s => s.ServiceCategory) // Explicitly include the related ServiceCategory. The error occurs because Entity Framework needs to be explicitly told to load related data. By adding .Include(s =&gt; s.ServiceCategory), we are instructing EF Core to perform a JOIN in the database to fetch the ServiceCategory details along with the Service. This makes the ServiceCategory property available to be used in the subsequent .Where() clause, which resolves the error and is the standard practice for querying related data.
            .Where(s => s.ServiceCategory.BusinessId == businessId)
            .Select(s => new ServiceDto
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                Duration = s.Duration,
                CategoryId = s.CategoryId
            }).ToListAsync();
    }

    // POST: api/services
    [HttpPost]
    [Authorize(Roles = "Admin,Business Owner")] // Only owners or admins can create services
    public async Task<ActionResult<ServiceDto>> PostService(CreateServiceDto createServiceDto)
    {
        // In a real app, you would verify the user owns the businessId provided
        var serviceCategory = await _context.ServiceCategories
            .FirstOrDefaultAsync(sc => sc.Id == createServiceDto.CategoryId && sc.BusinessId == createServiceDto.BusinessId);

        if (serviceCategory == null)
        {
            return BadRequest("Invalid Service Category.");
        }

        var service = new Service
        {
            Name = createServiceDto.Name,
            Price = createServiceDto.Price,
            Duration = TimeSpan.FromMinutes(createServiceDto.DurationMinutes),
            CategoryId = createServiceDto.CategoryId
        };

        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        var serviceDto = new ServiceDto { Id = service.Id, Name = service.Name, Price = service.Price, Duration = service.Duration, CategoryId = service.CategoryId };
        
        return CreatedAtAction(nameof(GetServices), new { id = service.Id }, serviceDto);
    }
}
