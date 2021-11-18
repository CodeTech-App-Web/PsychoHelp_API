using PsychoHelp_API.Psychologists.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Psychologists.Domain.Repositories
{
    public interface IPsychologistRepository
    {
        Task<IEnumerable<Psychologist>> ListAsync();
        Task AddAsync(Psychologist psychologist);
        Task<Psychologist> FindByIdAsync(int id);
        Task<Psychologist> FindByEmailAsync(string email);
        void Update(Psychologist psychologist);
        void Remove(Psychologist psychologist);
    }
}
