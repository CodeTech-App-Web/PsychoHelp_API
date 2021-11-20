using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.patients.Domain.Models;

namespace PsychoHelp_API.patients.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task<Patient> FindByIdAsync(int id);
        Task<Patient> FindByNameAsync(string name);
        Task<Patient> FindByEmailAsync(string email);
        Task AddSync(Patient patient);
        void Update(Patient patient);
        void Remove(Patient patient);
    }
}