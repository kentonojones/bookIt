// File: src/bookIt.Infrastructure/Data/ApplicationDbContext.cs
using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace bookIt.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ApiKey> ApiKeys { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<BlockedClient> BlockedClients { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessHoursException> BusinessHoursExceptions { get; set; }
    public DbSet<ClientPackage> ClientPackages { get; set; }
    public DbSet<ClientProfile> ClientProfiles { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<FormField> FormFields { get; set; }
    public DbSet<FormSubmission> FormSubmissions { get; set; }
    public DbSet<GiftCard> GiftCards { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<RatingAndReview> RatingsAndReviews { get; set; }
    public DbSet<RecurringAppointmentPattern> RecurringAppointmentPatterns { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<StaffAvailability> StaffAvailabilities { get; set; }
    public DbSet<StaffMember> StaffMembers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPreference> UserPreferences { get; set; }
    public DbSet<WaitlistEntry> WaitlistEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This line automatically finds and applies all configuration classes (like BusinessConfiguration)
        // from the current assembly (the Infrastructure project).
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}