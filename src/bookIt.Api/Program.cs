using bookIt.Infrastructure.Data;
using bookIt.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using bookIt.Application.Interfaces;
using bookIt.Infrastructure.Services;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// --- START: Enterprise Security (CORS) ---
// We must tell the API that our React app (running on localhost:5173) is allowed to call it.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>   
        {
            policy.WithOrigins("http://localhost:5173") // Default Vite Port
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// --- END: Enterprise Security (CORS) ---

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<AuditableEntityInterceptor>();

builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    var interceptor = sp.GetRequiredService<AuditableEntityInterceptor>();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString).AddInterceptors(interceptor);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CRITICAL: Apply the CORS policy before other middleware
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await bookIt.Infrastructure.Data.DataSeeder.SeedDataAsync(services);
}

app.Run();