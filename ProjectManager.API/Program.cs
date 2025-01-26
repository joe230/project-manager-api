using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectManager.API.Controllers;
using ProjectManager.Infrastructure.Extensions;
using ProjectManager.Infrastructure.Seeders;
using ProjectManager.Application.Extensions;
using ProjectManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Authentication with JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => 
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ClockSkew = TimeSpan.Zero
    };
});

// Add Swagger Configuration
builder.Services.AddSwaggerGenWithAuth();

// Add Presentation layer services
builder.Services.AddControllers();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

// Add Application and Domain layer services
builder.Services.AddApplication();

// Add Infrastructure layer services
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Create app scope for seeding the database on run
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IProjectSeeder>();
await seeder.Seed();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
