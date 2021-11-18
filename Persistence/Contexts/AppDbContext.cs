using System;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Appointments.Domain.Models;

namespace PsychoHelp_API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Logbook> Logbooks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Psychologist_Schedules
            

            //Psychologist

            //Constraints
            builder.Entity<Psychologist>().ToTable("Psychologists");
            builder.Entity<Psychologist>().HasKey(p => p.Id);
            builder.Entity<Psychologist>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Psychologist>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Psychologist>().Property(p => p.Age).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Dni).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Email).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Password).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Phone).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Specialization).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Formation).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.About).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Active).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.New).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Img).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Cmp).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.Genre).IsRequired();
            builder.Entity<Psychologist>().Property(p => p.SessionType).IsRequired();

            // Relationships
            builder.Entity<Psychologist>()
                .HasMany(p => p.Publications)
                .WithOne(p => p.Psychologist)
                .HasForeignKey(p => p.PsychologistId);

            //Sample Data
            builder.Entity<Psychologist>().HasData
                (
                new Psychologist
                { 
                    Id = 1, 
                    Name = "Juan Garcia",
                    Age = "28/04/2001",
                    Dni = 12345678, 
                    Email = "usuarios1@hotmail.com", 
                    Password = "123456789", 
                    Phone = 123456789, 
                    Specialization = "autoestima", 
                    Formation = "UPC", 
                    About = "qwertyuiop", 
                    Active = false, 
                    New = false, 
                    Img = "sadsdasda", 
                    Cmp = 987456, 
                    Genre = "Male", 
                    SessionType = "Individual"
                },
                new Psychologist
                {
                    Id = 2,
                    Name = "Ana Flores",
                    Age = "28/04/2001",
                    Dni = 12344569,                   
                    Email = "usuarios2@hotmail.com",
                    Password = "123456",
                    Phone = 987456123,
                    Specialization = "autoestima",
                    Formation = "UPC",
                    About = "qwertyuiop",
                    Active = false,
                    New = false,
                    Img = "sadsdasda",
                    Cmp = 123456,
                    Genre = "Male",
                    SessionType = "Individual"
                }
                );

            //Schedule

            //Constrains
            builder.Entity<Schedule>().ToTable("Schedules");
            builder.Entity<Schedule>().HasKey(p => p.Id);
            builder.Entity<Schedule>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Schedule>().Property(p => p.Time).IsRequired();

            //Sample Data
            builder.Entity<Schedule>().HasData
                (
                new Schedule { Id = 1, Time = "8:00"},
                new Schedule { Id = 2, Time = "9:00" },
                new Schedule { Id = 3, Time = "10:00" },
                new Schedule { Id = 4, Time = "11:00" },
                new Schedule { Id = 5, Time = "12:00" },
                new Schedule { Id = 6, Time = "16:00" },
                new Schedule { Id = 7, Time = "17:00" },
                new Schedule { Id = 8, Time = "18:00" },
                new Schedule { Id = 9, Time = "19:00" },
                new Schedule { Id = 10, Time = "20:00" }
                );

            //LogBook
            
            //Constraints
            builder.Entity<Logbook>().ToTable("LogBook");
            builder.Entity<Logbook>().HasKey(p => p.Id);
            builder.Entity<Logbook>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Logbook>().Property(p => p.ConsultationReason).HasMaxLength(300);
            builder.Entity<Logbook>().Property(p => p.PublicHistory).HasMaxLength(300);
            builder.Entity<Logbook>().Property(p => p.LogBookName).HasMaxLength(50);
            
            //Relationships
            /*builder.Entity<Logbook>().HasOne(p => p.Patient)
                .WithOne(p => p.Logbook)
                .HasForeignKey<Patient>(p => p.Id);*/
            
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
            builder.Entity<Patient>().Property(p => p.State).IsRequired();
            builder.Entity<Patient>().Property(p => p.Img);
            
            //Relationships
            builder.Entity<Patient>().HasOne(p => p.Logbook)
                .WithOne(p => p.Patient)
                .HasForeignKey<Logbook>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Publication

            //Constrains
            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(1000);            
            builder.Entity<Publication>().Property(p => p.CreatedAt).HasColumnType("DateTime");

            //Relationships
            builder.Entity<Publication>().HasMany(p => p.Tags)
                .WithOne(p => p.Publication)
                .HasForeignKey(p => p.PublicationId);

            //Sample Data
            builder.Entity<Publication>().HasData
            (
                new Publication { Id = 1, Title = "Prueba 1", Description = "Descripcion de Prueba", CreatedAt = DateTime.Parse("2021-11-01T03:49:49.450Z"), PsychologistId = 1 },
                new Publication { Id = 2, Title = "Prueba 2", Description = "Descripcion de Prueba", CreatedAt = DateTime.Parse("2021-11-01T03:49:49.450Z"), PsychologistId = 2 }
            );

            //Tag

            //Constrains
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Tag>().HasKey(p => p.Id);
            builder.Entity<Tag>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(p => p.Text).IsRequired();

            //Sample Data
            builder.Entity<Tag>().HasData
            (
            new Tag { Id = 1, Text = "Tag Prueba 1", PublicationId = 1 },
            new Tag { Id = 2, Text = "Tag Prueba 2", PublicationId = 1 },
            new Tag { Id = 3, Text = "Tag Prueba 3", PublicationId = 2 }
            );

            //Appointment 
            
            //Constrains
            builder.Entity<Appointment>().ToTable("Appointments");
            builder.Entity<Appointment>().HasKey(p => p.Id);
            builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.PsychoNotes).IsRequired().HasMaxLength(100);
            builder.Entity<Appointment>().Property(p => p.ScheduleDate).HasColumnType("timestamp");
            builder.Entity<Appointment>().Property(p => p.CreatedAt).HasColumnType("timestamp");
            builder.Entity<Appointment>().Property(p => p.PersonalHistory).IsRequired().HasMaxLength(200);
            builder.Entity<Appointment>().Property(p => p.Treatment).IsRequired().HasMaxLength(200);
            builder.Entity<Appointment>().Property(p => p.TestRealized).IsRequired().HasMaxLength(200);
            builder.Entity<Appointment>().Property(p => p.Motive).IsRequired().HasMaxLength(200);
            
            //Relationships
            builder.Entity<Appointment>()
                .HasOne(p => p.psychologist)
                .WithMany(pp => pp.Appointments)
                .HasForeignKey(pi => pi.PsychoId)
                .HasConstraintName("fk_appointment_psycho");

            builder.Entity<Appointment>()
                .HasOne(p => p.patient)
                .WithMany(pp => pp.Appointments)
                .HasForeignKey(pi => pi.PatientId)
                .HasConstraintName("fk_appointment_patient");

            //Sample Data
            // builder.Entity<Appointment>().HasData
            // (
            //     new Appointment { Id = 8, PsychoNotes = "Esta es una prueba del psicologo", ScheduleDate = DateTime.Parse("2021-11-03T10:00:20.450Z"), CreatedAt = DateTime.Parse("2021-11-01T03:49:49.450Z") },
            //     new Appointment { Id = 18, PsychoNotes = "Esta es la segunda prueba del psicologo", ScheduleDate = DateTime.Parse("2021-11-02T16:40:00.450Z"), CreatedAt = DateTime.Parse("2021-11-02T07:49:54.450Z") }
            // );
            
            // Apply Snake Case Naming Convention to All Objects
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
