using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Appointments.Domain.Services.Communication;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Services.Communication;
using PsychoHelp_API.Psychologists.Domain.Services.Communication;

namespace PsychoHelp_API.Appointments.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<AppointmentResponse> SaveAsync(Appointment appointment);
        Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment);
        Task<AppointmentResponse> DeleteAsync(int id);
        Task<Appointment> GetByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetByPsychologistIdAsync(int id);
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(int id);
        Task<IEnumerable<Patient>> GetPatientsByPsychologistIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAppointmentByPatientAndPsychologistIdAsync(int patientId, int psychologistId);
    }
}