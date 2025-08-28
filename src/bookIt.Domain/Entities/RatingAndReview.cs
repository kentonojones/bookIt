 File srcbookIt.DomainEntitiesRatingAndReview.cs
namespace bookIt.Domain.Entities;

public class RatingAndReview
{
    public int Id { get; set; }
    public int Rating { get; set; }  1-5
    public string Comment { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; }

     Foreign Key and Navigation Property for Appointment
    public int AppointmentId { get; set; }
    public virtual Appointment Appointment { get; set; } = null!;
}