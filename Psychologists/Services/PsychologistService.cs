using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Repositories;
using PsychoHelp_API.Psychologists.Domain.Services;
using PsychoHelp_API.Psychologists.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PsychoHelp_API.Domain.Repositories;

namespace PsychoHelp_API.Psychologists.Services
{
    public class PsychologistService : IPsychologistService
    {
        private readonly IPsychologistRepository _psychologistRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PsychologistService(IPsychologistRepository psychologistRepository, IUnitOfWork unitOfWork)
        {
            _psychologistRepository = psychologistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Psychologist>> ListAsync()
        {
            return await _psychologistRepository.ListAsync();
        }

        public async Task<PsychologistResponse> SaveAsync(Psychologist psychologist)
        {
            try
            {
                await _psychologistRepository.AddAsync(psychologist);
                await _unitOfWork.CompleteAsync();

                return new PsychologistResponse(psychologist);
            }
            catch (Exception e)
            {
                return new PsychologistResponse($"An error occurred while saving Psychologist: {e.Message}.");
            }
        }

        public async Task<PsychologistResponse> UpdateAsync(int id, Psychologist psychologist)
        {
            var existingPsychologist = await _psychologistRepository.FindByIdAsync(id);
            
            if (existingPsychologist == null)
                return new PsychologistResponse("Psychologist not fund.");

            existingPsychologist.Name = psychologist.Name;
            existingPsychologist.Age = psychologist.Age;
            existingPsychologist.Dni = psychologist.Dni;
            existingPsychologist.Email = psychologist.Email;
            existingPsychologist.Password = psychologist.Password;
            existingPsychologist.Phone = psychologist.Phone;
            existingPsychologist.Specialization = psychologist.Specialization;
            existingPsychologist.Formation = psychologist.Formation;
            existingPsychologist.About = psychologist.About;  
            existingPsychologist.Active = psychologist.Active; 
            existingPsychologist.New = psychologist.New;
            existingPsychologist.Img = psychologist.Img;
            existingPsychologist.Cmp = psychologist.Cmp;
            existingPsychologist.Genre = psychologist.Genre;
            existingPsychologist.SessionType = psychologist.SessionType;
            
            
            try
            {
                _psychologistRepository.Update(existingPsychologist);
                await _unitOfWork.CompleteAsync();

                return new PsychologistResponse(existingPsychologist);
            }
            catch (Exception e)
            {
                return new PsychologistResponse($"An error occurred while updating the psychologist: {e.Message}");
            }
        }

        public async Task<PsychologistResponse> DeleteAsync(int id)
        { 
            var existingPsychologist  = await _psychologistRepository.FindByIdAsync(id);

            if (existingPsychologist == null)
                return new PsychologistResponse("Psychologist not fund.");
            try
            {
                _psychologistRepository.Remove(existingPsychologist);
                await _unitOfWork.CompleteAsync();

                return new PsychologistResponse(existingPsychologist);
            }
            catch (Exception e)
            {
                return new PsychologistResponse($"An error occurred while deleting the psychologist: {e.Message}");
            }
        }

        public Task<Psychologist> GetByIdAsync(int id)
        {
            return _psychologistRepository.FindByIdAsync(id);
        }

        public Task<Psychologist> GetByEmailAsync(string email)
        {
            return _psychologistRepository.FindByEmailAsync(email);
        }

    }
}
