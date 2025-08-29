using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class FormSubmissionConfiguration : IEntityTypeConfiguration<FormSubmission>
{
    public void Configure(EntityTypeBuilder<FormSubmission> builder)
    {
        builder.HasOne(fs => fs.Appointment)
            .WithMany(a => a.FormSubmissions)
            .HasForeignKey(fs => fs.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}