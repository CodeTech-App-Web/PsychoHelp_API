using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PsychoHelp_API.Domain.Repositories;
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

        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
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
            var existingPublication = await _publicationRepository.FindByIdAsync(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found.");
            existingPublication.Title = publication.Title;
            existingPublication.Description = publication.Description;
            existingPublication.Tags = publication.Tags;            

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch(Exception e)
            {
                return new PublicationResponse($"An error occurred ehile updating the Publication: {e.Message}");

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
    } 
}