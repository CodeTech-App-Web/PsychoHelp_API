using AutoMapper;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Resources;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Resources;

namespace PsychoHelp_API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePsychologistResource, Psychologist>();
            CreateMap<SavePatientResource, Patient>();
            CreateMap<SaveLogBookResource, Logbook>();
        }
    }
}
