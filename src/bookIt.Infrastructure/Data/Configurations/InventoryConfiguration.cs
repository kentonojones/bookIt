using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bookIt.Infrastructure.Data.Configurations;
public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(i => new { i.ProductId, i.LocationId });

        builder.HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete cycles

        builder.HasOne(i => i.Location)
            .WithMany(l => l.Inventories)
            .HasForeignKey(i => i.LocationId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete cycles
    }
}