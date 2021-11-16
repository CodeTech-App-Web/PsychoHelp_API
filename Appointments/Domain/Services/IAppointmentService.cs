using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Appointments.Domain.Services.Communication;

namespace PsychoHelp_API.Appointments.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<AppointmentResponse> SaveAsync(Appointment appointment);
        Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment);
        Task<AppointmentResponse> DeleteAsync(int id);
    }
}