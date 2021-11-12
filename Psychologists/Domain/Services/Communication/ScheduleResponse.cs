using PsychoHelp_API.Domain.Services.Communication;
using PsychoHelp_API.Psychologists.Domain.Model;

namespace PsychoHelp_API.Psychologists.Domain.Services.Communication
{
    public class ScheduleResponse : BaseResponse<Schedule>
    {
        public ScheduleResponse(string message) : base(message)
        { }

        public ScheduleResponse(Schedule schedule) : base(schedule)
        { }
    }
}