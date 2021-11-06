using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Domain.Repositories;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Repositories;
using PsychoHelp_API.patients.Domain.Services;
using PsychoHelp_API.patients.Domain.Services.Communication;

namespace PsychoHelp_API.patients.Services
{
    public class LogbookService : ILogBookService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogBookRepository _logBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LogbookService(IPatientRepository patientRepository, ILogBookRepository logBookRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _logBookRepository = logBookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Logbook>> ListAsync()
        {
            return await _logBookRepository.ListAsync();
        }

        /*public async Task<Logbook> ListByPatientIdAsync(int patientId)
        {
            return await _logBookRepository.FindByPatientId(patientId);
        }*/

        public async Task<LogBookResponse> SaveAsync(Logbook logbook)
        {
            try
            {
                await _logBookRepository.AddAsync(logbook);
                await _unitOfWork.CompleteAsync();
                return new LogBookResponse(logbook);
            }
            catch (Exception e)
            {
                return new LogBookResponse($"An error occurred while saving Category: {e.Message}.");
            }
        }

        public async Task<LogBookResponse> UpdateAsync(int id, Logbook logbook)
        {
            var existingLogbook = await _logBookRepository.FindByIdAsync(id);

            if (existingLogbook == null)
                return new LogBookResponse("Category not found.");

            existingLogbook.ConsultationReason = logbook.ConsultationReason;
            existingLogbook.PublicHistory = logbook.PublicHistory;
            existingLogbook.LogBookName = logbook.LogBookName;

            try
            {
                _logBookRepository.Update(existingLogbook);
                await _unitOfWork.CompleteAsync();

                return new LogBookResponse(existingLogbook);
            }
            catch (Exception e)
            {
                return new LogBookResponse($"An error occurred while updating Category: {e.Message}.");
            }
        }

        public async Task<LogBookResponse> DeleteAsync(int id)
        {
            var existingLogbook = await _logBookRepository.FindByIdAsync(id);

            if (existingLogbook == null)
                return new LogBookResponse("Product not found");

            try
            {
                _logBookRepository.Remove(existingLogbook);
                await _unitOfWork.CompleteAsync();

                return new LogBookResponse(existingLogbook);
            }
            catch (Exception e)
            {
                return new LogBookResponse($"An error occurred while deleting the product {e.Message}");
            }
        }
    }
}