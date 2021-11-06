using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Repositories;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;

namespace PsychoHelp_API.patients.Persistence.Repositories
{
    public class LogBookRepository : BaseRepository, ILogBookRepository
    {
        public LogBookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Logbook>> ListAsync()
        {
            return await _context.Logbooks.ToListAsync();
        }

        /*public async Task<Logbook> FindByPatientId(int patientId)
        {
            return await _context.Logbooks
                .Where(p => p.PatientId == patientId)
                .FirstOrDefaultAsync();
        }*/

        public async Task<Logbook> FindByIdAsync(int id)
        {
            return await _context.Logbooks
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Logbook logbook)
        {
            await _context.AddAsync(logbook);
        }

        public void Update(Logbook logbook)
        {
            _context.Logbooks.Update(logbook);
        }

        public void Remove(Logbook logbook)
        {
            _context.Logbooks.Remove(logbook);
        }
    }
}