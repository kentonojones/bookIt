using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class ClientProfileConfiguration : IEntityTypeConfiguration<ClientProfile>
{
    public void Configure(EntityTypeBuilder<ClientProfile> builder)
    {
        builder.HasOne(cp => cp.User).WithMany(u => u.ClientProfiles).HasForeignKey(cp => cp.UserId);
        builder.HasOne(cp => cp.Business).WithMany().HasForeignKey(cp => cp.BusinessId);
    }
}