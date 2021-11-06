using PsychoHelp_API.Domain.Services.Communication;
using PsychoHelp_API.patients.Domain.Models;

namespace PsychoHelp_API.patients.Domain.Services.Communication
{
    public class PatientResponse: BaseResponse<Patient>
    {
        public PatientResponse(string message) : base(message)
        {
        }

        public PatientResponse(Patient resource) : base(resource)
        {
        }
    }
}