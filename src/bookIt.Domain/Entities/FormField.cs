// File: src/bookIt.Domain/Entities/FormField.cs
namespace bookIt.Domain.Entities;

public class FormField : BaseEntity
{
    public string Question { get; set; } = string.Empty;
    public string FieldType { get; set; } = string.Empty; // e.g., Text, Checkbox, Date
    public bool IsRequired { get; set; }

    // Foreign Key and Navigation Property for Form
    public int FormId { get; set; }
    public virtual Form Form { get; set; } = null!;
}