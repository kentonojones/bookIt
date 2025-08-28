// File: src/bookIt.Domain/Entities/Service.cs
namespace bookIt.Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }

    // Foreign Key and Navigation Property for Category
    public int CategoryId { get; set; }
    public virtual ServiceCategory Category { get; set; } = null!;
    
    // Navigation property
    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}