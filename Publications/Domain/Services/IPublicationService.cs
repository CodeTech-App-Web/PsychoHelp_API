using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Domain.Services.Communication;

namespace PsychoHelp_API.Publications.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task<IEnumerable<Publication>> ListByPsychologistIdAsync(int psychologistId);
        Task<PublicationResponse> SaveAsync(Publication publication);
        Task<PublicationResponse> UpdateAsync(int id, Publication publication);
        Task<PublicationResponse> DeleteAsync(int id);
    }
}