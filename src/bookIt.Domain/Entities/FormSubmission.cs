// File: src/bookIt.Domain/Entities/FormSubmission.cs
namespace bookIt.Domain.Entities;

public class FormSubmission : BaseEntity
{
    public string Answers { get; set; } = string.Empty; // Stored as a JSON string

    // Foreign Key and Navigation Property for Appointment
    public int AppointmentId { get; set; }
    public virtual Appointment Appointment { get; set; } = null!;
}