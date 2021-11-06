using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Services;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.patients.Resources;

namespace PsychoHelp_API.patients.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogBookService _logBookService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper, ILogBookService logBookService)
        {
            _patientService = patientService;
            _mapper = mapper;
            _logBookService = logBookService;
        }

        [HttpGet]
        public async Task<IEnumerable<PatientResource>> GetAllAsync()
        {
            var patients = await _patientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientResource>>(patients);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePatientResource resource)
        {
            //Logbook
            SaveLogBookResource logbookResource = new SaveLogBookResource();
            
            var logbook = _mapper.Map<SaveLogBookResource, Logbook>(logbookResource);
            await _logBookService.SaveAsync(logbook);

            //Patient
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var patient = _mapper.Map<SavePatientResource, Patient>(resource);
            patient.SetLogBook(logbook);
            var result = await _patientService.SaveAsync(patient);

            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);

            return Ok(patientResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] SavePatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var patient = _mapper.Map<SavePatientResource, Patient>(resource);
            var result = await _patientService.UpdateAsync(id, patient);
            
            if(!result.Success)
                return BadRequest(result.Message);
            
            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _patientService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);
        }
    }
}