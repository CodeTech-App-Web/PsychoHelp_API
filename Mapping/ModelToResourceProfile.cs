using AutoMapper;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Resources;

namespace PsychoHelp_API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Psychologist, PsychologistResource>();
        }
    }
}
