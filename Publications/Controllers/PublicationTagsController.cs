using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Domain.Services;
using PsychoHelp_API.Publications.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Controllers
{
    [Route("api/v1/publications/{publicationId}/tags")]
    [ApiController]
    public class PublicationTagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
               
        public PublicationTagsController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllTagsByPublicationId(int publicationId)
        {
            var tags = await _tagService.ListByPublicationId(publicationId);
            var resources = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);
            return resources;
        }

    }
}
