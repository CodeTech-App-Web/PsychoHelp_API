using AutoMapper;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Appointments.Resources;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Resources;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Resources;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Resources;

namespace PsychoHelp_API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Psychologist, PsychologistResource>();
            CreateMap<Patient, PatientResource>();
            CreateMap<Logbook, LogBookResource>();
            CreateMap<Publication, PublicationResource>();
            CreateMap<Appointment, AppointmentResource>();
            CreateMap<Tag, TagResource>();
        }
    }
}
