using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;
using PsychoHelp_API.Appointments.Domain.Repositories;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.Psychologists.Domain.Model;

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

        public async Task<IEnumerable<Patient>> FindPatientsByPsychologistIdAsync(int id)
        {
            return await _context.Appointments
                .Where(a => a.PsychoId == id)
                .Select(a => a.patient)
                .Distinct()
                .ToListAsync();

            /*return await _context.Appointments
                .Include(a => a.patient)
                .Where(a => a.PsychoId == id)
                .Select(a => a.patient)

                .ToListAsync();*/
        }

        public async Task<IEnumerable<Appointment>> FindByPatientAndPsychologistIdAsync(int patientId, int psychologistId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == patientId && a.PsychoId == psychologistId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> FindAppointmentsByPsychologistIdAsync(int id)
        {
            return await _context.Appointments
                .Where(a => a.PsychoId == id)
                .ToListAsync();
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