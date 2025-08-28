// File: src/bookIt.Domain/Entities/Resource.cs
namespace bookIt.Domain.Entities;

public class Resource
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Foreign Key and Navigation Property for Location
    public int LocationId { get; set; }
    public virtual Location Location { get; set; } = null!;
}