using PsychoHelp_API.Publications.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Domain.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task AddAsync(Tag tag);
        Task<Tag> FindById(int id);
        Task<IEnumerable<Tag>> FindByPublicationIdAsync(int publicationId);
        void Update(Tag tag);
        void Remove(Tag tag);

    }
}
