using PsychoHelp_API.patients.Domain.Models;

namespace PsychoHelp_API.patients.Domain.Services.Communication
{
    public class LogBookResponse : BaseResponse<Logbook>
    {
        public LogBookResponse(string message) : base(message) { }
        
        public LogBookResponse(Logbook resource) : base(resource) { }
    }
}