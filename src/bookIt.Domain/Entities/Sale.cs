// File: src/bookIt.Domain/Entities/Sale.cs
namespace bookIt.Domain.Entities;

public class Sale : BaseEntity
{
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }

    // Foreign Keys and Navigation Properties
    public int ClientId { get; set; }
    public virtual User Client { get; set; } = null!;

    public int StaffMemberId { get; set; }
    public virtual StaffMember StaffMember { get; set; } = null!;
}