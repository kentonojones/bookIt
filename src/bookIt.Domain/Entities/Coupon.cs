// File: src/bookIt.Domain/Entities/Coupon.cs
namespace bookIt.Domain.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public decimal DiscountAmount { get; set; }
    public bool IsPercentage { get; set; }
    public DateOnly ExpiryDate { get; set; }
}