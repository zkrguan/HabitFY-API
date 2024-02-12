using HabitFY_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using HabitFY_API.Controllers;
using HabitFY_API.Repositories;
using HabitFY_API.Repositories.UnitOfWork;
using Asp.Versioning;
using HabitFY_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//-------------------------------------------------
// Builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// Adding AWS-COGNITO securing the route
builder.Services.AddCognitoIdentity();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Cognito:Authority"];
        options.TokenValidationParameters = options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
        };
    }
);
//-------------------------------------------------
// Add CORS services and define a policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//_________________
// Add entity framework to the 

// The Official manual recommended way to connect
// https://learn.microsoft.com/en-us/azure/azure-sql/database/azure-sql-dotnet-entity-framework-core-quickstart?view=azuresql&tabs=visual-studio%2Cservice-connector%2Cportal
var connection = String.Empty;
// Build configuration
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

connection = config.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// -------------------------------------------------
// Setting up api versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1); // default version is 1 
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

// -------------------------------------------------
builder.Services.AddControllers();
// ___________________________________
// Registering the UserProfile services
builder.Services.AddScoped<UserProfileService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS with the defined policy
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
