// File: src/bookIt.Domain/Entities/BusinessHoursException.cs
namespace bookIt.Domain.Entities;

public class BusinessHoursException : BaseEntity
{
    public DateOnly Date { get; set; }
    public bool IsUnavailable { get; set; }
    // Nullable Start/End times allow for overriding regular hours on a specific day
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    // Foreign Key and Navigation Property for Staff Member
    public int StaffMemberId { get; set; }
    public virtual StaffMember StaffMember { get; set; } = null!;
}