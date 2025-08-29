// File: src/bookIt.Domain/Entities/Business.cs
namespace bookIt.Domain.Entities;

public class Business : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }

    // Foreign Key and Navigation Property for Owner
    public int OwnerId { get; set; }
    public virtual User Owner { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    public virtual ICollection<ServiceCategory> ServiceCategories { get; set; } = new List<ServiceCategory>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();
    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();
}