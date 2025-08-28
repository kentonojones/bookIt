// File: src/bookIt.Domain/Entities/ApiKey.cs
namespace bookIt.Domain.Entities;

public class ApiKey
{
    public int Id { get; set; }
    public string KeyHash { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }

    // Foreign Key and Navigation Property for Business
    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;
}