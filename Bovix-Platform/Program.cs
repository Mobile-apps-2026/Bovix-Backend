using Microsoft.EntityFrameworkCore;
using Bovix_Platform.RanchManagement.Application.Internal.CommandServices;
using Bovix_Platform.RanchManagement.Application.Internal.QueryServices;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.RanchManagement.Domain.Services;
using Bovix_Platform.RanchManagement.Infrastructure.Persistence.EFC.Repositories;
using Bovix_Platform.Shared.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Interfaces.ASAP.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Bovix_Platform.IAM.Application.OutBoundServices;
using Bovix_Platform.IAM.Domain.Repositories;
using Bovix_Platform.IAM.Domain.Services;
using Bovix_Platform.IAM.Infrastructure.Repositories;
using Bovix_Platform.IAM.Application.CommandServices;
using Bovix_Platform.IAM.Infrastructure.Hashing.BCrypt.Services;
using Bovix_Platform.IAM.Infrastructure.Tokens.JWT.Services;
using Bovix_Platform.IAM.Infrastructure.Tokens.JWT.Configuration;
using Microsoft.OpenApi.Models;
using Bovix_Platform.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Bovix_Platform.IAM.Application.QueryServices;
using Bovix_Platform.Shared.Infrastructure.Media.Cloudinary;
using Bovix_Platform.Shared.Application.OutboundServices;
using dotenv.net;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
builder.Services.AddSwaggerGen(
    c =>
    {
        c.EnableAnnotations();

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });

/////////////////////////Begin Database Configuration/////////////////////////
// Add DbContext
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"server={dbServer};database={dbDatabase};user={dbUser};password={dbPassword};SslMode=Required;";

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection string
if (connectionString is null)
    throw new Exception("Database connection string is not set");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMediaStorageService, CloudinaryService>();

// Bounded Context Injection Configuration for Business

//IAM BC
builder.Services.AddScoped<IUserRepostory, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

//Ranch Management BC
builder.Services.AddScoped<IBovineRepository, BovineRepository>();
builder.Services.AddScoped<IBovineQueryService, BovineQueryService>();
builder.Services.AddScoped<IBovineCommandService, BovineCommandService>();

builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IVaccineQueryService, VaccineQueryService>();
builder.Services.AddScoped<IVaccineCommandService, VaccineCommandService>();

builder.Services.AddScoped<IStableRepository, StableRepository>();
builder.Services.AddScoped<IStableQueryService, StableQueryService>();
builder.Services.AddScoped<IStableCommandService, StableCommandService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();

builder.Services.AddScoped<IClinicalRecordRepository, ClinicalRecordRepository>();
builder.Services.AddScoped<IClinicalRecordQueryService, ClinicalRecordQueryService>();
builder.Services.AddScoped<IClinicalRecordCommandService, ClinicalRecordCommandService>();

builder.Services.AddScoped<IFeedingPlanRepository, FeedingPlanRepository>();
builder.Services.AddScoped<IFeedingPlanQueryService, FeedingPlanQueryService>();
builder.Services.AddScoped<IFeedingPlanCommandService, FeedingPlanCommandService>();


/////////////////////////End Database Configuration/////////////////////////
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

// Add Authorization Middleware to Pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();