using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;
using PsychoHelp_API.Appointments.Domain.Repositories;

namespace PsychoHelp_API.Appointments.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task<Appointment> FindByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _context.Appointments.ToListAsync();
        }
        
        public void Remove(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }
        
        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }
    }
}