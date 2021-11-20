using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Persistence.Repositories;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Persistence.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
        }

        public void Remove(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public async Task<Tag> FindById(int id)
        {
            return await _context.Tags
                .Include(p => p.Publication)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Tag>> FindByPublicationIdAsync(int publicationId)
        {
            return await _context.Tags
                .Where(p => p.PublicationId == publicationId)
                .Include(p => p.Publication)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _context.Tags
                .Include(p => p.Publication)
                .ToListAsync();
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }
    }
}
