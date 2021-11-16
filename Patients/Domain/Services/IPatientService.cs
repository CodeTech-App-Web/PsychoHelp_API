using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Services.Communication;

namespace PsychoHelp_API.patients.Domain.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task<PatientResponse> SaveAsync(Patient patient);
        Task<PatientResponse> UpdateAsync(int id, Patient patient);
        Task<PatientResponse> DeleteAsync(int id);
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> GetByEmailAsync(string email);
    }
}