using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Services.Communication;

namespace PsychoHelp_API.Psychologists.Domain.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> ListAsync();
        Task<ScheduleResponse> SaveAsync(Schedule schedule);
    }
}