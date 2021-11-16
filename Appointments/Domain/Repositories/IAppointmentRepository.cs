using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Appointments.Domain.Models;

namespace PsychoHelp_API.Appointments.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task AddAsync(Appointment publication);
        Task<Appointment> FindByIdAsync(int id);
        void Update(Appointment publication);
        void Remove(Appointment publication);
    }
}