using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Psychologists.Domain.Services
{
    public interface IPsychologistService
    {
        Task<IEnumerable<Psychologist>> ListAsync();
        Task<PsychologistResponse> SaveAsync(Psychologist psychologist);

        Task<PsychologistResponse> UpdateAsync(int id, Psychologist psychologist);
        Task<PsychologistResponse> DeleteAsync(int id);

        Task<Psychologist> GetByIdAsync(int id);
        Task<Psychologist> GetByEmailAsync(string email);

    }
}
