using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PsychoHelp_API.Psychologists.Domain.Repositories;
using PsychoHelp_API.Psychologists.Domain.Services;
using PsychoHelp_API.Psychologists.Persistence.Repositories;
using PsychoHelp_API.Psychologists.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PsychoHelp_API.Appointments.Domain.Repositories;
using PsychoHelp_API.Appointments.Domain.Services;
using PsychoHelp_API.Appointments.Persistence.Repositories;
using PsychoHelp_API.Appointments.Services;
using PsychoHelp_API.Domain.Repositories;
using PsychoHelp_API.patients.Domain.Repositories;
using PsychoHelp_API.patients.Domain.Services;
using PsychoHelp_API.patients.Persistence.Repositories;
using PsychoHelp_API.patients.Services;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;
using PsychoHelp_API.Publications.Domain.Repositories;
using PsychoHelp_API.Publications.Domain.Services;
using PsychoHelp_API.Publications.Persistence.Repositories;
using PsychoHelp_API.Publications.Services;

namespace PsychoHelp_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("psychohelp-api-in-memory");
            });
            services.AddScoped<IPsychologistRepository, PsychologistRepository >();
            services.AddScoped<IPsychologistService, PsychologistService>();
            
            services.AddScoped<ILogBookRepository, LogBookRepository>();
            services.AddScoped<ILogBookService, LogbookService>();
            
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPublicationService, PublicationService>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();
                       
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PsychoHelp_API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PsychoHelp_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
