using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Resources;
using AutoMapper;

namespace PsychoHelp_API.patients.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Patient, PatientResource>();
            CreateMap<Logbook, LogBookResource>();
        }
    }
}