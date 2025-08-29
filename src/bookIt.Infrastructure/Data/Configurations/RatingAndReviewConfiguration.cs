using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class RatingAndReviewConfiguration : IEntityTypeConfiguration<RatingAndReview>
{
    public void Configure(EntityTypeBuilder<RatingAndReview> builder)
    {
        builder.HasOne(r => r.Appointment)
            .WithMany(a => a.Reviews)
            .HasForeignKey(r => r.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}