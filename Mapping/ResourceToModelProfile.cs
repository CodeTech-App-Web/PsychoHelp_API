using AutoMapper;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Resources;

namespace PsychoHelp_API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePatientResource, Patient>();
            CreateMap<SaveLogBookResource, Logbook>();
        }
    }
}