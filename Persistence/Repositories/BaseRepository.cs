using PsychoHelp_API.Persistence.Contexts;

namespace PsychoHelp_API.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}