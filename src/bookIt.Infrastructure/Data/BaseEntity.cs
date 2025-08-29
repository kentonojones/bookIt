// File: src/bookIt.Domain/Entities/BaseEntity.cs
// NOTE: You will need to update ALL your other entity classes to inherit from this class.
// For example: `public class Business : BaseEntity`
namespace bookIt.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}