// File: src/bookIt.Domain/Entities/WaitlistEntry.cs
namespace bookIt.Domain.Entities;

public class WaitlistEntry
{
    public int Id { get; set; }
    public DateTime RequestDate { get; set; }

    // Foreign Keys and Navigation Properties
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int StaffMemberId { get; set; }
    public virtual StaffMember StaffMember { get; set; } = null!;
}