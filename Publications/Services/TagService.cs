using PsychoHelp_API.Domain.Repositories;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Domain.Repositories;
using PsychoHelp_API.Publications.Domain.Services;
using PsychoHelp_API.Publications.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublicationRepository _publicationRepository;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork, IPublicationRepository publicationRepository)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _publicationRepository = publicationRepository;
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _tagRepository.ListAsync();
        }

        public async Task<IEnumerable<Tag>> ListByPublicationId(int publicationId)
        {
            return await _tagRepository.FindByPublicationIdAsync(publicationId);
        }

        public async Task<TagResponse> SaveAsync(Tag tag)
        {
            // Validate PublicationId
            var existingPublication = await _publicationRepository.FindByIdAsync(tag.PublicationId);

            if (existingPublication == null)
                return new TagResponse("This publication doesn't exist.");

            try
            {
                await _tagRepository.AddAsync(tag);
                await _unitOfWork.CompleteAsync();

                return new TagResponse(tag);
            }
            catch(Exception e)
            {
                return new TagResponse($"An error ocurred while saving Tag: {e.Message}");
            }
        }

       /* public async Task<TagResponse> UpdateAsync(int id, Tag tag)
        {
            // Validate If Tag Exists
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("Tag not found.");

            // Validate PublicationId
            var existingPublication = await _publicationRepository.FindByIdAsync(tag.PublicationId);
            if (existingPublication == null)
                return new TagResponse("Invalid Publication");

            existingTag.Text = tag.Text;
            existingTag.PublicationId = tag.PublicationId;

            try
            {
                _tagRepository.Update(existingTag);
                await _unitOfWork.CompleteAsync();

                return new TagResponse(existingTag);
            }
            catch(Exception e)
            {
                return new TagResponse($"An error ocurred while updating the Tag: {e.Message}");
            }
            
        }*/

        public async Task<TagResponse> DeleteAsync(int id)
        {
            // Validate If Tag Exists
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("Tag not found.");

            try
            {
                _tagRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();

                return new TagResponse(existingTag);
            }
            catch(Exception e)
            {
                return new TagResponse($"An error ocurred while deleting the Tag: {e.Message}");
            }

        }
    }
}
