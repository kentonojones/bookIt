using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class BlockedClientConfiguration : IEntityTypeConfiguration<BlockedClient>
{
    public void Configure(EntityTypeBuilder<BlockedClient> builder)
    {
        builder.HasKey(bc => new { bc.BusinessId, bc.UserId });
        
        builder.HasOne(bc => bc.Business)
            .WithMany()
            .HasForeignKey(bc => bc.BusinessId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete from Business

        builder.HasOne(bc => bc.User)
            .WithMany()
            .HasForeignKey(bc => bc.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete from User
    }
}