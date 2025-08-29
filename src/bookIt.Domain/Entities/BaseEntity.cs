// File: src/bookIt.Domain/Entities/BaseEntity.cs

namespace bookIt.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}