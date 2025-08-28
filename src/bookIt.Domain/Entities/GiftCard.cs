// File: src/bookIt.Domain/Entities/GiftCard.cs
namespace bookIt.Domain.Entities;

public class GiftCard
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal InitialBalance { get; set; }
    public decimal CurrentBalance { get; set; }
}