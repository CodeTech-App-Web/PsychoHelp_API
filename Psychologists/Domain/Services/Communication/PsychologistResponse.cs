using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Domain.Services.Communication;

namespace PsychoHelp_API.Psychologists.Domain.Services.Communication
{
    public class PsychologistResponse : BaseResponse<Psychologist>
    {
        public PsychologistResponse(string message) : base(message)
        { }

        public PsychologistResponse(Psychologist psychologist) : base(psychologist)
        { }

    }
}
