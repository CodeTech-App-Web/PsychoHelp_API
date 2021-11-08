using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Domain.Services.Communication;

namespace PsychoHelp_API.Appointments.Domain.Services.Communication
{
    public class AppointmentResponse : BaseResponse<Appointment>
    {
        public AppointmentResponse(string message) : base(message)
        {
        }

        public AppointmentResponse(Appointment appointment) : base(appointment)
        {
        }
    }
}