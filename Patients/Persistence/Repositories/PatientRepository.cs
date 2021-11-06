using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Repositories;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;

namespace PsychoHelp_API.patients.Persistence.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> ListAsync()
        {
            return await _context.Patients
                //.Include(p => p.Logbook)
                .ToListAsync();
        }

        public async Task<Patient> FindByIdAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.Logbook)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> FindByNameAsync(string name)
        {
            return await _context.Patients
                .Include(p => p.Logbook)
                .FirstOrDefaultAsync(p => p.FirstName + " " + p.LastName == name);
        }

        public async Task<Patient> FindByEmailAsync(string email)
        {
            return await _context.Patients
                .Include(p => p.Logbook)
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task AddSync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}