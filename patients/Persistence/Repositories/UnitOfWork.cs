using System.Threading.Tasks;
using PsychoHelp_API.patients.Domain.Repositories;
using PsychoHelp_API.patients.Persistence.Contexts;

namespace PsychoHelp_API.patients.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}