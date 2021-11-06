using System.Threading.Tasks;

namespace PsychoHelp_API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}