using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.Psychologists.Domain.Model;

namespace PsychoHelp_API.Appointments.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task AddAsync(Appointment publication);
        Task<Appointment> FindByIdAsync(int id);
        Task<IEnumerable<Patient>> FindPatientsByPsychologistIdAsync(int id);
        Task<IEnumerable<Appointment>> FindByPatientAndPsychologistIdAsync(int patientId, int psychologistId);
        Task<IEnumerable<Appointment>> FindAppointmentsByPsychologistIdAsync(int id);
        Task<IEnumerable<Appointment>> FindAppointmentsByPatientIdAsync(int id);
        void Update(Appointment publication);
        void Remove(Appointment publication);
    }
}