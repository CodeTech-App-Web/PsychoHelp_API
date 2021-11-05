using System.Threading.Tasks;

namespace PsychoHelp_API.patients.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}