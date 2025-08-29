// File: src/bookIt.Domain/Entities/GiftCard.cs
namespace bookIt.Domain.Entities;

public class GiftCard : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public decimal InitialBalance { get; set; }
    public decimal CurrentBalance { get; set; }
}