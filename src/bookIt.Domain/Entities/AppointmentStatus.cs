// File: src/bookIt.Domain/Entities/AppointmentStatus.cs
namespace bookIt.Domain.Entities;

public class AppointmentStatus
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty; // e.g., Scheduled, Completed, Cancelled, NoShow
}