using bookIt.Infrastructure.Data;
using bookIt.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add this line to register controllers

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- START: Database Configuration ---

// 1. Register the custom interceptor as a scoped service.
builder.Services.AddScoped<AuditableEntityInterceptor>();

// 2. Register the ApplicationDbContext and configure it to use SQL Server and the interceptor.
builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    var interceptor = sp.GetRequiredService<AuditableEntityInterceptor>();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString).AddInterceptors(interceptor);
});

// --- END: Database Configuration ---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); // Add this line for authorization middleware

app.MapControllers(); // Add this line to map controller routes

app.Run();
