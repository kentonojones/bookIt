using bookIt.Application.Dtos;
using bookIt.Domain.Entities;
using bookIt.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt; // Required for JwtRegisteredClaimNames
using System.Security.Claims;

namespace bookIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/appointments
    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> CreateAppointment(CreateAppointmentDto createDto)
    {
        var clientIdClaim = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (!int.TryParse(clientIdClaim, out var clientId))
        {
            return Unauthorized("Invalid token.");
        }
        
        var service = await _context.Services.FindAsync(createDto.ServiceId);
        var scheduledStatus = await _context.AppointmentStatuses.FirstAsync(s => s.Status == "Scheduled");

        if (service == null)
        {
            return BadRequest("Invalid Service.");
        }

        var appointment = new Appointment
        {
            StartTime = createDto.StartTime,
            EndTime = createDto.StartTime.Add(service.Duration),
            ClientId = clientId,
            ServiceId = createDto.ServiceId,
            StaffMemberId = createDto.StaffMemberId,
            StatusId = scheduledStatus.Id
        };
        
        // In a real app, you would add logic here to prevent double booking.

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        
        var appointmentDto = new AppointmentDto
        {
            Id = appointment.Id,
            StartTime = appointment.StartTime,
            EndTime = appointment.EndTime,
            ClientId = appointment.ClientId,
            ServiceId = appointment.ServiceId,
            StaffMemberId = appointment.StaffMemberId,
            Status = scheduledStatus.Status
        };

        return Ok(appointmentDto);
    }
}
