// File: src/bookIt.Domain/Entities/Form.cs
namespace bookIt.Domain.Entities;

public class Form : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    // Foreign Key and Navigation Property for Business
    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;

    // Navigation property
    public virtual ICollection<FormField> Fields { get; set; } = new List<FormField>();
}