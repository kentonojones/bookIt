using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class StaffMemberConfiguration : IEntityTypeConfiguration<StaffMember>
{
    public void Configure(EntityTypeBuilder<StaffMember> builder)
    {
        builder.HasOne(s => s.User)
            .WithMany(u => u.StaffAssignments)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete cycles

        builder.HasOne(s => s.Location)
            .WithMany(l => l.StaffMembers)
            .HasForeignKey(s => s.LocationId);
    }
}