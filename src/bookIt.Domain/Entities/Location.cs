// File: src/bookIt.Domain/Entities/Location.cs
namespace bookIt.Domain.Entities;

public class Location : BaseEntity
{
    public string Address { get; set; } = string.Empty;

    // Foreign Key and Navigation Property for Business
    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<StaffMember> StaffMembers { get; set; } = new List<StaffMember>();
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}