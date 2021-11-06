using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.Domain.Repositories;
using PsychoHelp_API.patients.Domain.Services;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.patients.Resources;
using PsychoHelp_API.patients.Services;

namespace PsychoHelp_API.patients.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class LogbooksController: ControllerBase
    {
        private readonly ILogBookService _logbookService;
        private readonly IMapper _mapper;

        public LogbooksController(ILogBookService logbookService, IMapper mapper)
        {
            _logbookService = logbookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LogBookResource>> GetAllAsync()
        {
            var logbooks = await _logbookService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Logbook>, IEnumerable<LogBookResource>>(logbooks);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLogBookResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var logbook = _mapper.Map<SaveLogBookResource, Logbook>(resource);
            var result = await _logbookService.SaveAsync(logbook);

            if (!result.Success)
                return BadRequest(result.Message);

            var logBookResource = _mapper.Map<Logbook, LogBookResource>(result.Resource);

            return Ok(logBookResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] SaveLogBookResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var logbook = _mapper.Map<SaveLogBookResource, Logbook>(resource);
            var result = await _logbookService.UpdateAsync(id, logbook);
            
            if(!result.Success)
                return BadRequest(result.Message);
            
            var logBookResource = _mapper.Map<Logbook, LogBookResource>(result.Resource);
            return Ok(logBookResource);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _logbookService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var logBookResource = _mapper.Map<Logbook, LogBookResource>(result.Resource);
            return Ok(logBookResource);
        }
        
    }
}