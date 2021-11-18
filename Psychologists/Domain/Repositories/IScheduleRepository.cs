using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Psychologists.Domain.Model;

namespace PsychoHelp_API.Psychologists.Domain.Repositories
{
    public interface IScheduleRepository
    {
        Task <IEnumerable<Schedule>> ListAsync();
        Task AddAsync(Schedule schedule);
        Task<Schedule> FindByIdScheduleAsync(int id);
    }
}