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
                    Email = "juangarcia@hotmail.com", 
                    Password = "123456789", 
                    Phone = 123456789, 
                    Specialization = "Esteem", 
                    Formation = "Postgraduate course in sexual diversity and human rights - Universidad Alas Peruanas", 
                    About = "I love my work as a therapist, I feel privileged to work on what I have studied so much for. This gives me a fresh and committed style when it comes to serving you.I highly value a sense of humor, creativity and wit when it comes to intervening.", 
                    Active = false, 
                    New = false, 
                    Img = "https://bullseye-magazine.eu/wp-content/uploads/2019/09/portrait_test.jpg", 
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
                    Email = "anaflores@hotmail.com",
                    Password = "ana123456",
                    Phone = 987456123,
                    Specialization = "Esteem",
                    Formation = "Bachelor of Psychology - Universidad Nacional Mayor de San Marcos",
                    About = "I am a happy and empathetic person. I enjoy meeting people from different cultures and discovering different ways of perceiving the world. I love listening to music and watching classic movies. I practice Yoga and Meditation in order to be more and more focused on the present moment.",
                    Active = false,
                    New = false,
                    Img = "https://www.enseignemoi-files.com/site/view/images/dyn-cache/pages/image/img/12/20/1427215436_122008_1200x667x0.jpg?v=2018021301",
                    Cmp = 123456,
                    Genre = "Female",
                    SessionType = "Individual"
                },
                new Psychologist
                {
                    Id = 3,
                    Name = "Juan Perez",
                    Age = "17/04/1996",
                    Dni = 72058669,
                    Email = "juanperez@hotmail.com",
                    Password = "juan1234",
                    Phone = 987489966,
                    Specialization = "Depression",
                    Formation = "Bachelor of Psychology - Technological University of Peru",
                    About = "I am a person who enjoys the therapeutic space. I constantly seek to update myself, preserving the essence of psychotherapy, thus generating a warm relationship of respect and empathy, with a vision of growth for my patients.",
                    Active = false,
                    New = false,
                    Img = "https://www.magisnet.com/wp-content/uploads/2021/04/Tal-BenShahar.jpg",
                    Cmp = 123456,
                    Genre = "Male",
                    SessionType = "Couple"
                },
                new Psychologist
                {
                    Id = 4,
                    Name = "Silvia Muñoz",
                    Age = "18/11/1985",
                    Dni = 12344569,
                    Email = "silvia.m@hotmail.com",
                    Password = "sil123456",
                    Phone = 987456123,
                    Specialization = "Codependency",
                    Formation = "Bachelor of Psychology - Universidad Nacional Mayor de San Marcos",
                    About = "Passionate about the social and human sciences that seek to understand the complexity of the human being, especially psychology and its various expressions. Lover of nature, plants, animals and my family. Any outdoor plan is always a good plan.",
                    Active = false,
                    New = false,
                    Img = "https://img.freepik.com/foto-gratis/mujer-hermosa-joven-mirando-camara-chica-moda-verano-casual-camiseta-blanca-pantalones-cortos-hembra-positiva-muestra-emociones-faciales-modelo-divertido-aislado-amarillo_158538-15796.jpg?size=626&ext=jpg",
                    Cmp = 123456,
                    Genre = "Female",
                    SessionType = "Couple"
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
                new Schedule { Id = 4, Time = "11:00" }
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
            builder.Entity<Publication>().Property(p => p.Description).IsRequired();         
            builder.Entity<Publication>().Property(p => p.CreatedAt).HasColumnType("DateTime");
            builder.Entity<Publication>().Property(p => p.Img);

            //Relationships
            builder.Entity<Publication>().HasMany(p => p.Tags)
                .WithOne(p => p.Publication)
                .HasForeignKey(p => p.PublicationId);

            //Sample Data
            builder.Entity<Publication>().HasData
            (
                new Publication
                {
                    Id = 1,
                    Title = "How to beat anxiety?",
                    Description = "Anxiety is a mental problem that affects the health of many people. Anxiety is a feeling of fear, fear, and restlessness. It can make you sweat, feel restless and tense, and have palpitations. It can be a normal reaction to stress. For example, you may feel anxious when faced with a difficult problem at work, before taking an exam, or before making an important decision.",
                    CreatedAt = DateTime.Parse("2021-11-01T03:49:49.450Z"),
                    Img = "https://estaticos.muyinteresante.es/media/cache/1140x_thumb/uploads/images/article/5e6b7bc55bafe86b2ccdb361/ansiedad-corona_0.jpg",
                    PsychologistId = 1
                },
                new Publication
                {
                    Id = 2,
                    Title = "How to help a person with depression?",
                    Description = "Depression is one of the most difficult mental problems to treat. That is why in this chapter we will teach you how to support a person who has symptoms of depression.",
                    CreatedAt = DateTime.Parse("2021-11-01T03:49:49.450Z"),
                    Img = "https://assets.weforum.org/article/image/responsive_large_E79PmG1Oop_9P7-edBkH9JddpXUpnaVEz2cvg8KkYOE.jpg",
                    PsychologistId = 2
                },
                new Publication
                {
                    Id = 3,
                    Title = "Learning about negative emotions",
                    Description = "We can all recognize those emotions that we like, pleasant emotions. Who doesn't like to feel happy, excited, in love, etc. But on the other hand, we also recognize emotions that can be more uncomfortable, for example, sadness, shame, guilt and anger.",
                    CreatedAt = DateTime.Parse("2021-11-01T03:49:49.450Z"),
                    Img = "https://gentequebrilla.azurewebsites.net/wp-content/uploads/2019/04/12014-1024x604.jpg",
                    PsychologistId = 2
                }
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
            new Tag { Id = 1, Text = "#anxiety", PublicationId = 1 },
            new Tag { Id = 2, Text = "#fear", PublicationId = 1 },
            new Tag { Id = 3, Text = "#depression", PublicationId = 2 },
            new Tag { Id = 4, Text = "#sadness", PublicationId = 2},
            new Tag { Id = 5, Text = "#emotions", PublicationId = 3 },
            new Tag { Id = 6, Text = "#negativity", PublicationId = 3 }
            );

            //Appointment 
            
            //Constrains
            builder.Entity<Appointment>().ToTable("Appointments");
            builder.Entity<Appointment>().HasKey(p => p.Id);
            builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.PsychoNotes).IsRequired().HasMaxLength(100);
            builder.Entity<Appointment>().Property(p => p.ScheduleDate).HasColumnType("timestamp");
            builder.Entity<Appointment>().Property(p => p.CreatedAt).HasColumnType("timestamp");
            
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
