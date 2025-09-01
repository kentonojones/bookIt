using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookIt.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ApiKey> ApiKeys { get; }
    DbSet<Appointment> Appointments { get; }
    DbSet<AppointmentStatus> AppointmentStatuses { get; }
    DbSet<AuditLog> AuditLogs { get; }
    DbSet<BlockedClient> BlockedClients { get; }
    DbSet<Business> Businesses { get; }
    DbSet<BusinessHoursException> BusinessHoursExceptions { get; }
    DbSet<ClientPackage> ClientPackages { get; }
    DbSet<ClientProfile> ClientProfiles { get; }
    DbSet<Coupon> Coupons { get; }
    DbSet<Form> Forms { get; }
    DbSet<FormField> FormFields { get; }
    DbSet<FormSubmission> FormSubmissions { get; }
    DbSet<GiftCard> GiftCards { get; }
    DbSet<Inventory> Inventories { get; }
    DbSet<Location> Locations { get; }
    DbSet<Notification> Notifications { get; }
    DbSet<Package> Packages { get; }
    DbSet<Payment> Payments { get; }
    DbSet<Product> Products { get; }
    DbSet<RatingAndReview> RatingsAndReviews { get; }
    DbSet<RecurringAppointmentPattern> RecurringAppointmentPatterns { get; }
    DbSet<Resource> Resources { get; }
    DbSet<Role> Roles { get; }
    DbSet<Sale> Sales { get; }
    DbSet<Service> Services { get; }
    DbSet<ServiceCategory> ServiceCategories { get; }
    DbSet<StaffAvailability> StaffAvailabilities { get; }
    DbSet<StaffMember> StaffMembers { get; }
    DbSet<User> Users { get; }
    DbSet<UserPreference> UserPreferences { get; }
    DbSet<WaitlistEntry> WaitlistEntries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

