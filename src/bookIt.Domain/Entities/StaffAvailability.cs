// File: src/bookIt.Domain/Entities/StaffAvailability.cs
namespace bookIt.Domain.Entities;

public class StaffAvailability : BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    // Foreign Key and Navigation Property for Staff Member
    public int StaffMemberId { get; set; }
    public virtual StaffMember StaffMember { get; set; } = null!;
}