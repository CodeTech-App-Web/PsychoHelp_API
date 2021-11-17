using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.patients.Domain.Models;

namespace PsychoHelp_API.patients.Domain.Repositories
{
    public interface ILogBookRepository
    {
        Task<IEnumerable<Logbook>> ListAsync();
        //Task<Logbook> FindByPatientId(int patientId);
        Task<Logbook> FindByIdAsync(int id);
        
        Task AddAsync(Logbook logbook);
        void Update(Logbook logbook);
        void Remove(Logbook logbook);
    }
}