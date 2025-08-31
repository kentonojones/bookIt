using bookIt.Domain.Entities;
using bookIt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using bookIt.Application.Interfaces;

namespace bookIt.Application.Services;

public class AvailabilityService
{
    private readonly ApplicationDbContext _context;

    public AvailabilityService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TimeSpan>> GetAvailableSlots(int staffMemberId, int serviceId, DateTime date)
    {
        var staffMember = await _context.StaffMembers.FindAsync(staffMemberId);
        var service = await _context.Services.FindAsync(serviceId);
        if (staffMember == null || service == null)
        {
            return new List<TimeSpan>(); // Return empty list if inputs are invalid
        }

        // 1. Get recurring availability for the given day
        var dayOfWeek = date.DayOfWeek;
        var recurringAvailability = await _context.StaffAvailabilities
            .FirstOrDefaultAsync(a => a.StaffMemberId == staffMemberId && a.DayOfWeek == dayOfWeek);

        // 2. Check for exceptions
        var exception = await _context.BusinessHoursExceptions
            .FirstOrDefaultAsync(e => e.StaffMemberId == staffMemberId && e.Date == DateOnly.FromDateTime(date));

        TimeSpan startTime;
        TimeSpan endTime;

        if (exception != null)
        {
            if (exception.IsUnavailable) return new List<TimeSpan>(); // Staff member is off
            startTime = exception.StartTime.Value;
            endTime = exception.EndTime.Value;
        }
        else if (recurringAvailability != null)
        {
            startTime = recurringAvailability.StartTime;
            endTime = recurringAvailability.EndTime;
        }
        else
        {
            return new List<TimeSpan>(); // No availability defined
        }
        
        // 3. Get all existing appointments for that day
        var existingAppointments = await _context.Appointments
            .Where(a => a.StaffMemberId == staffMemberId && a.StartTime.Date == date.Date)
            .ToListAsync();
            
        // 4. Generate potential slots and filter out conflicts
        var availableSlots = new List<TimeSpan>();
        var potentialSlot = startTime;
        
        while (potentialSlot.Add(service.Duration) <= endTime)
        {
            var isSlotAvailable = !existingAppointments.Any(a =>
                potentialSlot < a.EndTime.TimeOfDay && potentialSlot.Add(service.Duration) > a.StartTime.TimeOfDay
            );

            if (isSlotAvailable)
            {
                availableSlots.Add(potentialSlot);
            }

            potentialSlot = potentialSlot.Add(TimeSpan.FromMinutes(15)); // Check every 15 minutes
        }

        return availableSlots;
    }
}