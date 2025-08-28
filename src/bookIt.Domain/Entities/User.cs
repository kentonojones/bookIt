// File: src/bookIt.Domain/Entities/User.cs
namespace bookIt.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }

    // Foreign Key and Navigation Property for Role
    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<StaffMember> StaffAssignments { get; set; } = new List<StaffMember>();
    public virtual ICollection<Appointment> ClientAppointments { get; set; } = new List<Appointment>();
    public virtual ICollection<ClientProfile> ClientProfiles { get; set; } = new List<ClientProfile>();
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    public virtual ICollection<UserPreference> Preferences { get; set; } = new List<UserPreference>();
}