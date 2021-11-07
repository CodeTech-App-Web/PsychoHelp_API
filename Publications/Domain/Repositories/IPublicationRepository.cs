using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Publications.Domain.Models;

namespace PsychoHelp_API.Publications.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddAsync(Publication publication);
        Task<Publication> FindByIdAsync(int id);
        void Update(Publication publication);
        void Remove(Publication publication);
        
    }
}