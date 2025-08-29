using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class RecurringAppointmentPatternConfiguration : IEntityTypeConfiguration<RecurringAppointmentPattern>
{
    public void Configure(EntityTypeBuilder<RecurringAppointmentPattern> builder)
    {
        builder.HasOne(p => p.OriginalAppointment).WithOne(a => a.RecurringAppointmentPattern).HasForeignKey<RecurringAppointmentPattern>(p => p.AppointmentId);
    }
}