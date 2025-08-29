// File: src/bookIt.Domain/Entities/UserPreference.cs
namespace bookIt.Domain.Entities;

public class UserPreference : BaseEntity
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    // Foreign Key and Navigation Property for User
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}