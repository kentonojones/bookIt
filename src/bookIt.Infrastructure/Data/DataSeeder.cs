using bookIt.Application.Interfaces;
using bookIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace bookIt.Infrastructure.Data;

public static class SeedDataConfiguration
{
    // User Roles
    public static readonly string[] RoleNames = { "Admin", "Business Owner", "Staff", "Client" };

    // Appointment Statuses
    public static readonly string[] StatusNames = { "Pending Confirmation", "Scheduled", "Arrived", "Completed", "Cancelled by Client", "Cancelled by Business", "NoShow", "Rescheduled" };

    // User Details
    public static readonly (string Email, string Role)[] Users =
    {
        ("admin@bookit.com", "Admin"),
        ("john.owner@example.com", "Business Owner"),
        ("steve.staff@example.com", "Staff"),
        ("carol.staff@example.com", "Staff"),
        ("liam.client@example.com", "Client"),
        ("olivia.client@example.com", "Client"),
        ("noah.client@example.com", "Client"),
        ("emma.client@example.com", "Client"),
        ("william.client@example.com", "Client"),
        ("ava.client@example.com", "Client")
    };
    public const string DefaultPassword = "Password123!";

    // Business Details
    public const string BusinessName = "Capital Barbershop";
    public static readonly string[] LocationAddresses = { "123 Main St, Fredericton, NB", "456 Queen St, Fredericton, NB" };
    public const string ServiceCategoryName = "Haircuts";

    // Service Details
    public static readonly (string Name, decimal Price, int DurationMinutes)[] Services =
    {
        ("Men's Cut", 30.00m, 30),
        ("Beard Trim", 15.00m, 15),
        ("Hot Towel Shave", 45.00m, 45),
        ("Kids Cut (Under 12)", 25.00m, 30),
        ("Buzz Cut", 20.00m, 15),
        ("Line Up / Shape Up", 10.00m, 10),
        ("Shampoo & Style", 25.00m, 20),
        ("Head Shave", 35.00m, 30),
        ("Long Haircut", 40.00m, 45),
        ("Blending Color", 50.00m, 30),
        ("Nose Wax", 12.00m, 10),
        ("Father & Son Package", 50.00m, 60)
    };

    // Staff Availability (Monday to Friday)
    public static readonly (DayOfWeek Day, TimeSpan Start, TimeSpan End)[] Availabilities =
    {
        (DayOfWeek.Monday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
        (DayOfWeek.Tuesday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
        (DayOfWeek.Wednesday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
        (DayOfWeek.Thursday, new TimeSpan(10, 0, 0), new TimeSpan(19, 0, 0)),
        (DayOfWeek.Friday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0))
    };
}

public static class DataSeeder
{
    public static async Task SeedDataAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        await context.Database.EnsureCreatedAsync();

        await SeedRolesAsync(context);
        await SeedAppointmentStatusesAsync(context);
        await SeedUsersAsync(context, passwordHasher);
        await SeedBusinessDataAsync(context);
    }

    private static async Task SeedRolesAsync(ApplicationDbContext context)
    {
        if (await context.Roles.AnyAsync()) return;
        var roles = SeedDataConfiguration.RoleNames.Select(name => new Role { Name = name });
        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();
    }

    private static async Task SeedAppointmentStatusesAsync(ApplicationDbContext context)
    {
        if (await context.AppointmentStatuses.AnyAsync()) return;
        var statuses = SeedDataConfiguration.StatusNames.Select(status => new AppointmentStatus { Status = status });
        await context.AppointmentStatuses.AddRangeAsync(statuses);
        await context.SaveChangesAsync();
    }

    private static async Task SeedUsersAsync(ApplicationDbContext context, IPasswordHasher passwordHasher)
    {
        if (await context.Users.AnyAsync()) return;

        var roles = await context.Roles.ToDictionaryAsync(r => r.Name, r => r.Id);
        var users = SeedDataConfiguration.Users.Select(u => new User
        {
            Email = u.Email,
            PasswordHash = passwordHasher.HashPassword(SeedDataConfiguration.DefaultPassword),
            RoleId = roles[u.Role]
        });
        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();
    }

   private static async Task SeedBusinessDataAsync(ApplicationDbContext context)
   {
       if (await context.Businesses.AnyAsync()) return;

       var owner = await context.Users.SingleAsync(u => u.Email == "john.owner@example.com");
       var staffUser1 = await context.Users.SingleAsync(u => u.Email == "steve.staff@example.com");
       var staffUser2 = await context.Users.SingleAsync(u => u.Email == "carol.staff@example.com");
       var clientUser = await context.Users.SingleAsync(u => u.Email == "liam.client@example.com");
       var scheduledStatus = await context.AppointmentStatuses.SingleAsync(s => s.Status == "Scheduled");

       var business = new Business { Name = SeedDataConfiguration.BusinessName, OwnerId = owner.Id };
       await context.Businesses.AddAsync(business);
       await context.SaveChangesAsync();

       var mainStreetLocation = new Location { Address = SeedDataConfiguration.LocationAddresses[0], BusinessId = business.Id };
       var queenStreetLocation = new Location { Address = SeedDataConfiguration.LocationAddresses[1], BusinessId = business.Id };
       await context.Locations.AddRangeAsync(mainStreetLocation, queenStreetLocation);
       await context.SaveChangesAsync();

       var staffMember1 = new StaffMember { UserId = staffUser1.Id, LocationId = mainStreetLocation.Id };
       var staffMember2 = new StaffMember { UserId = staffUser2.Id, LocationId = queenStreetLocation.Id };
       await context.StaffMembers.AddRangeAsync(staffMember1, staffMember2);
       await context.SaveChangesAsync();

       var serviceCategory = new ServiceCategory { Name = SeedDataConfiguration.ServiceCategoryName, BusinessId = business.Id };
       await context.ServiceCategories.AddAsync(serviceCategory);
       await context.SaveChangesAsync();

       var services = SeedDataConfiguration.Services.Select(s => new Service 
       { 
           Name = s.Name, 
           Price = s.Price, 
           Duration = TimeSpan.FromMinutes(s.DurationMinutes), 
           CategoryId = serviceCategory.Id 
       });
       await context.Services.AddRangeAsync(services);
       await context.SaveChangesAsync();

       var availabilities = SeedDataConfiguration.Availabilities.Select(a => new StaffAvailability
       {
           DayOfWeek = a.Day,
           StartTime = a.Start,
           EndTime = a.End,
           StaffMemberId = staffMember1.Id // Assigning availability to staff member 1 for simplicity
       });
       await context.StaffAvailabilities.AddRangeAsync(availabilities);
       await context.SaveChangesAsync();

       var mensCutService = await context.Services.SingleAsync(s => s.Name == "Men's Cut");
       var nextTuesday = DateTime.Now.Date.AddDays(((int)DayOfWeek.Tuesday - (int)DateTime.Now.DayOfWeek + 7) % 7);
       if (nextTuesday <= DateTime.Now.Date) nextTuesday = nextTuesday.AddDays(7);

       var appointment = new Appointment
       {
           StartTime = new DateTime(nextTuesday.Year, nextTuesday.Month, nextTuesday.Day, 10, 0, 0),
           EndTime = new DateTime(nextTuesday.Year, nextTuesday.Month, nextTuesday.Day, 10, 30, 0),
           ClientId = clientUser.Id,
           ServiceId = mensCutService.Id,
           StaffMemberId = staffMember1.Id,
           StatusId = scheduledStatus.Id
       };
       await context.Appointments.AddAsync(appointment);
       await context.SaveChangesAsync();
   }
}