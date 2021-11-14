using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Domain.Services;
using PsychoHelp_API.Publications.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagsController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        // GET api/<TagController>/
        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllAsync()
        {
            var tags = await _tagService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);
            return resources;
        }

        //POST api/<TagController>/
        [HttpPost]
        public async Task<IActionResult>PostAsync([FromBody] SaveTagResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tag = _mapper.Map<SaveTagResource, Tag>(resource);
            var result = await _tagService.SaveAsync(tag);

            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource);
            return Ok(tagResource);
        } 

        // DELETE api/<TagController>/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _tagService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource);
            return Ok(tagResource);
        }


    }
}
