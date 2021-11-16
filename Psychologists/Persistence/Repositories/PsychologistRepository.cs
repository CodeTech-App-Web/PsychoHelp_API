using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;

namespace PsychoHelp_API.Psychologists.Persistence.Repositories
{
    public class PsychologistRepository : BaseRepository, IPsychologistRepository
    {
        public PsychologistRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Psychologist>> ListAsync()
        {
            return await _context.Psychologists.ToListAsync();
        } 
        
        public async Task AddAsync(Psychologist psychologist)
        {
            await _context.Psychologists.AddAsync(psychologist);
        }

        public async Task<Psychologist> FindByIdAsync(int id)
        { 
            return await _context.Psychologists.FindAsync(id);
        }

        public void Update(Psychologist psychologist)
        {
            _context.Psychologists.Update(psychologist);
        }

        public void Remove(Psychologist psychologist)
        {
            _context.Psychologists.Remove(psychologist);
        }
    }
}
