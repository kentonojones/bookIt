using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(l => l.Address).HasMaxLength(500).IsRequired();
        builder.HasOne(l => l.Business).WithMany(b => b.Locations).HasForeignKey(l => l.BusinessId);
    }
}