using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.HasQueryFilter(b => !b.IsDeleted);
        builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
        builder.HasOne(b => b.Owner).WithMany().HasForeignKey(b => b.OwnerId).IsRequired();
    }
}