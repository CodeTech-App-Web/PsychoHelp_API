using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Services.Communication;

namespace PsychoHelp_API.patients.Domain.Services
{
    public interface ILogBookService
    {
        Task<IEnumerable<Logbook>> ListAsync();
        //Task<Logbook> ListByPatientIdAsync(int patientId);
        Task<LogBookResponse> SaveAsync(Logbook logbook);
        Task<LogBookResponse> UpdateAsync(int id, Logbook logbook);
        Task<LogBookResponse> DeleteAsync(int id);
    }
}