using PsychoHelp_API.patients.Persistence.Contexts;

namespace PsychoHelp_API.patients.Persistence.Repositories
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