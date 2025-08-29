using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.Property(t => t.KeyHash).IsRequired();
        builder.HasOne(t => t.Business).WithMany(b => b.ApiKeys).HasForeignKey(t => t.BusinessId);
    }
}