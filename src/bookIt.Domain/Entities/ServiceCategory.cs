// File: src/bookIt.Domain/Entities/ServiceCategory.cs
namespace bookIt.Domain.Entities;

public class ServiceCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Foreign Key and Navigation Property for Business
    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;

    // Navigation property
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}