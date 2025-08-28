// File: src/bookIt.Domain/Entities/Role.cs
namespace bookIt.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation property for the one-to-many relationship
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}