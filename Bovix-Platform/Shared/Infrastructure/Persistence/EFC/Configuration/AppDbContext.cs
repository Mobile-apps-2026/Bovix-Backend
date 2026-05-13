using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Bovix_Platform.IAM.Domain.Model.Aggregates;

namespace Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* IAM BC  */
        //User
        builder.Entity<User>().HasKey(f => f.Id);
        builder.Entity<User>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(f => f.Username).IsRequired();
        builder.Entity<User>().Property(f => f.Password).IsRequired();
        builder.Entity<User>().Property(f => f.Email).IsRequired();

        /* Ranch Management BC -------------------------------------------------------------------------------------- */
        //Bovine
        builder.Entity<Bovine>().HasKey(f => f.Id);
        builder.Entity<Bovine>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Bovine>().Property(f => f.Name).IsRequired();
        builder.Entity<Bovine>().Property(f => f.Gender).IsRequired();
        builder.Entity<Bovine>().Property(f => f.BirthDate).IsRequired();
        builder.Entity<Bovine>().Property(f => f.Breed).IsRequired();
        builder.Entity<Bovine>().Property(f => f.Location).IsRequired();
        builder.Entity<Bovine>().Property(f => f.BovineImg).IsRequired();
        builder.Entity<Bovine>().Property(f => f.StableId).IsRequired();
        builder.Entity<Bovine>().Property(f => f.Lot).HasMaxLength(20);
        builder.Entity<Bovine>().Property(f => f.Status).IsRequired().HasMaxLength(20);
        builder.Entity<Bovine>().Property(f => f.WeightKg).IsRequired();

        //Vaccine
        builder.Entity<Vaccine>().HasKey(f => f.Id);
        builder.Entity<Vaccine>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vaccine>().Property(f => f.Name).IsRequired();
        builder.Entity<Vaccine>().Property(f => f.VaccineType).IsRequired();
        builder.Entity<Vaccine>().Property(f => f.VaccineDate).IsRequired();
        builder.Entity<Vaccine>().Property(f => f.VaccineImg).IsRequired();
        builder.Entity<Vaccine>().Property(f => f.BovineId).IsRequired();

        //Stable
        builder.Entity<Stable>().HasKey(f => f.Id);
        builder.Entity<Stable>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Stable>().Property(f => f.Limit).IsRequired();

        //Appointment
        builder.Entity<Appointment>().HasKey(f => f.Id);
        builder.Entity<Appointment>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointment>().Property(f => f.VeterinarianName).IsRequired().HasMaxLength(150);
        builder.Entity<Appointment>().Property(f => f.ScheduledAt).IsRequired();
        builder.Entity<Appointment>().Property(f => f.Lot).HasMaxLength(20);
        builder.Entity<Appointment>().Property(f => f.Status).IsRequired().HasMaxLength(20);
        builder.Entity<Appointment>().Property(f => f.Notes).HasMaxLength(500);

        //ClinicalRecord
        builder.Entity<ClinicalRecord>().HasKey(f => f.Id);
        builder.Entity<ClinicalRecord>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ClinicalRecord>().Property(f => f.BovineId).IsRequired();
        builder.Entity<ClinicalRecord>().Property(f => f.RecordDate).IsRequired();
        builder.Entity<ClinicalRecord>().Property(f => f.Diagnosis).IsRequired().HasMaxLength(200);
        builder.Entity<ClinicalRecord>().Property(f => f.Treatment).HasMaxLength(500);
        builder.Entity<ClinicalRecord>().Property(f => f.Severity).IsRequired().HasMaxLength(20);
        builder.Entity<ClinicalRecord>().Property(f => f.VeterinarianName).HasMaxLength(150);

        //FeedingPlan
        builder.Entity<FeedingPlan>().HasKey(f => f.Id);
        builder.Entity<FeedingPlan>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FeedingPlan>().Property(f => f.Lot).IsRequired().HasMaxLength(20);
        builder.Entity<FeedingPlan>().Property(f => f.DailyRationKg).IsRequired();
        builder.Entity<FeedingPlan>().Property(f => f.AnimalCount).IsRequired();
        builder.Entity<FeedingPlan>().Property(f => f.Notes).HasMaxLength(300);

        //FeedingComponent (composición de cada plan)
        builder.Entity<FeedingComponent>().HasKey(f => f.Id);
        builder.Entity<FeedingComponent>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FeedingComponent>().Property(f => f.Name).IsRequired().HasMaxLength(100);
        builder.Entity<FeedingComponent>().Property(f => f.Percentage).IsRequired();
        builder.Entity<FeedingComponent>().Property(f => f.AmountKg).IsRequired();
        builder.Entity<FeedingComponent>().Property(f => f.FeedingPlanId).IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
}
