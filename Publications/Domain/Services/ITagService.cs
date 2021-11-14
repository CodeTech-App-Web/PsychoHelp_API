using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Domain.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task<IEnumerable<Tag>> ListByPublicationId(int publicationId);
        Task<TagResponse> SaveAsync(Tag tag);
        Task<TagResponse> UpdateAsync(int id, Tag tag);
        Task<TagResponse> DeleteAsync(int id);
    }
}
