using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Domain.Repositories;
using PsychoHelp_API.Psychologists.Domain.Repositories;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Domain.Repositories;
using PsychoHelp_API.Publications.Domain.Services;
using PsychoHelp_API.Publications.Domain.Services.Communication;

namespace PsychoHelp_API.Publications.Services
{
   public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPsychologistRepository _psychologistRepository;

        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork, IPsychologistRepository psychologistRepository)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
            _psychologistRepository = psychologistRepository;
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            // Validate PsychologistId
            var existingPsychologist = _psychologistRepository.FindByIdAsync(publication.PsychologistId);

            if (existingPsychologist == null)
                return new PublicationResponse("This psychologist doesn't exist");

            try
            {
                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(publication);
            }
            catch(Exception e)
            {
                return new PublicationResponse($"An error occurred while saving Publication: {e.Message} ");
            }
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            // Validate If Publication Exists
            var existingPublication = await _publicationRepository.FindByIdAsync(id);
            if (existingPublication == null)
                return new PublicationResponse("Publication not found.");

            // Validate PsychologistId
            var existingPsychologist = _psychologistRepository.FindByIdAsync(publication.PsychologistId);
            if (existingPsychologist == null)
                return new PublicationResponse("Invalid Psychologist");

            existingPublication.Title = publication.Title;
            existingPublication.Description = publication.Description;            
            //existingPublication.Tags = publication.Tags;
            //existingPublication.PsychologistId = publication.PsychologistId;

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch(Exception e)
            {
                return new PublicationResponse($"An error occurred while updating the Publication: {e.Message}");

            }
        }

        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindByIdAsync(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found.");

            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch(Exception e)
            {
                return new PublicationResponse($"An error occurred while deleting the Publication: {e.Message}");
            }
        }

        public async Task<IEnumerable<Publication>> ListByPsychologistIdAsync(int psychologistId)
        {
            return await _publicationRepository.FindByPsychologistIdAsync(psychologistId);
        }

        public Task<Publication> GetByIdAsync(int id)
        {
            return _publicationRepository.FindByIdAsync(id);
        }
    } 
}