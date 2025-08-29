// File: src/bookIt.Domain/Entities/StaffMember.cs
namespace bookIt.Domain.Entities;

public class StaffMember : BaseEntity
{
    // Foreign Keys and Navigation Properties
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public int LocationId { get; set; }
    public virtual Location Location { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<StaffAvailability> Availabilities { get; set; } = new List<StaffAvailability>();
    public virtual ICollection<BusinessHoursException> AvailabilityExceptions { get; set; } = new List<BusinessHoursException>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}