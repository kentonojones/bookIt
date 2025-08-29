// File: src/bookIt.Domain/Entities/Payment.cs
namespace bookIt.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public string StripeTransactionId { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }

    // Foreign Key and Navigation Property for Appointment
    public int AppointmentId { get; set; }
    public virtual Appointment Appointment { get; set; } = null!;
}