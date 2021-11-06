using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Services;
using PsychoHelp_API.Psychologists.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.Psychologists.Domain.Services.Communication;

namespace PsychoHelp_API.Psychologists.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PsychologistsController : ControllerBase
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IMapper _mapper;

        public PsychologistsController(IPsychologistService psychologistService, IMapper mapper)
        {
            _psychologistService = psychologistService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PsychologistResource>> GetAllAsync()
        {
            var psychologists = await _psychologistService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Psychologist>, IEnumerable<PsychologistResource>>(psychologists);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePsychologistResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var psychologist = _mapper.Map<SavePsychologistResource, Psychologist>(resource);

            var result = await _psychologistService.SaveAsync(psychologist);

            if (!result.Success)
                return BadRequest(result.Message);

            var psychologistResource = _mapper.Map<Psychologist, PsychologistResource>(result.Resource);
            return Ok(psychologistResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePsychologistResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var psychologist = _mapper.Map<SavePsychologistResource, Psychologist>(resource);
            var result = await _psychologistService.UpdateAsync(id, psychologist);

            if (!result.Success)
                return BadRequest(result.Message);

            var psychologistResource = _mapper.Map<Psychologist, PsychologistResource>(result.Resource);
            return Ok(psychologistResource);

        }
    }
}
