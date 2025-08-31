using bookIt.Application.Interfaces;
using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
// Ensure the correct namespace for IApplicationDbContext is included
namespace bookIt.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ApiKey> ApiKeys { get; } // <-- REMOVE 'set;' FROM ALL DBSETS
    public DbSet<Appointment> Appointments { get; }
    // ... all other DbSets without 'set;' ...
    public DbSet<WaitlistEntry> WaitlistEntries { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}