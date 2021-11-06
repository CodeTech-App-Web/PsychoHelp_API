using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.patients.Domain.Models;

namespace PsychoHelp_API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Logbook> Logbooks { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //LogBook
            
            //Constraints
            builder.Entity<Logbook>().ToTable("LogBook");
            builder.Entity<Logbook>().HasKey(p => p.Id);
            builder.Entity<Logbook>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Logbook>().Property(p => p.ConsultationReason).HasMaxLength(300);
            builder.Entity<Logbook>().Property(p => p.PublicHistory).HasMaxLength(300);
            builder.Entity<Logbook>().Property(p => p.LogBookName).HasMaxLength(50);
            
            //Relationships
            builder.Entity<Logbook>().HasOne(p => p.Patient)
                .WithOne(p => p.Logbook)
                .HasForeignKey<Patient>(p => p.Id);
            
            //Patient
            
            //Constraints
            builder.Entity<Patient>().ToTable("Patient");
            builder.Entity<Patient>().HasKey(p => p.Id);
            builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Patient>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Patient>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Patient>().Property(p => p.Email).IsRequired();
            builder.Entity<Patient>().Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Entity<Patient>().Property(p => p.Gender).IsRequired();
            builder.Entity<Patient>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
            builder.Entity<Patient>().Property(p => p.Date).IsRequired();
            builder.Entity<Patient>().Property(p => p.Img);
        }
    }
}