using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Domain.Repositories;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Repositories;
using PsychoHelp_API.Psychologists.Domain.Services;
using PsychoHelp_API.Psychologists.Domain.Services.Communication;

namespace PsychoHelp_API.Psychologists.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleService(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        {
            _scheduleRepository = scheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _scheduleRepository.ListAsync();
        }

        public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
        {
            try
            {
                await _scheduleRepository.AddAsync(schedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(schedule);
            }
            catch (Exception e)
            {
                return new ScheduleResponse($"An error occurred while saving Schedule: {e.Message}");
            }
        }
    }
}