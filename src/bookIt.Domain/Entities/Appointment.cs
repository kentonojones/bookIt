// File: src/bookIt.Domain/Entities/Appointment.cs
namespace bookIt.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // Foreign Keys and Navigation Properties
    public int ClientId { get; set; }
    public virtual User Client { get; set; } = null!;

    public int ServiceId { get; set; }
    public virtual Service Service { get; set; } = null!;

    public int StaffMemberId { get; set; }
    public virtual StaffMember StaffMember { get; set; } = null!;

    public int StatusId { get; set; }
    public virtual AppointmentStatus Status { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<RatingAndReview> Reviews { get; set; } = new List<RatingAndReview>();
    public virtual ICollection<FormSubmission> FormSubmissions { get; set; } = new List<FormSubmission>();
    public virtual RecurringAppointmentPattern? RecurringAppointmentPattern { get; set; }
}