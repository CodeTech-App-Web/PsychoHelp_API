using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Repositories;

namespace PsychoHelp_API.Psychologists.Persistence.Repositories
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        public ScheduleRepository(AppDbContext context) : base(context) 
        { }
        
        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task AddAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
        }

        public async Task<Schedule> FindByIdScheduleAsync(int id)
        {
            return await _context.Schedules.FindAsync(id);
        }
    }
}