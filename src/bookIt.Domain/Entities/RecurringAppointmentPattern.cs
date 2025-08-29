// File: src/bookIt.Domain/Entities/RecurringAppointmentPattern.cs
namespace bookIt.Domain.Entities;

public class RecurringAppointmentPattern : BaseEntity
{
    public string Frequency { get; set; } = string.Empty; // e.g., Weekly, Monthly
    public int Interval { get; set; } // e.g., every 2 weeks -> Frequency=Weekly, Interval=2
    public DateOnly EndDate { get; set; }

    // Foreign Key and Navigation Property for the original Appointment
    public int AppointmentId { get; set; }
    public virtual Appointment OriginalAppointment { get; set; } = null!;
}