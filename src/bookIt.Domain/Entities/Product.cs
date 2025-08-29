// File: src/bookIt.Domain/Entities/Product.cs
namespace bookIt.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Foreign Key and Navigation Property for Business
    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;
}