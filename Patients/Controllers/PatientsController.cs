using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Domain.Services;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.patients.Domain.Repositories;
using PsychoHelp_API.patients.Resources;
using PsychoHelp_API.Persistence.Contexts;

namespace PsychoHelp_API.patients.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogBookService _logBookService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper, ILogBookService logBookService, AppDbContext context)
        {
            _patientService = patientService;
            _mapper = mapper;
            _logBookService = logBookService;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PatientResource>> GetAllAsync()
        {
            var patients = await _patientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientResource>>(patients);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdAsync(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
                return NotFound();
            var resource = _mapper.Map<Patient, PatientResource>(patient);
            return Ok(resource);
        }
        
        [HttpGet ("email/{patientEmail}")]
        public async Task<IActionResult> GetByEmailAsync(string patientEmail)
        {
            var patient = await _patientService.GetByEmailAsync(patientEmail);
            if (patient == null)
                return NotFound();
            var resource = _mapper.Map<Patient, PatientResource>(patient);
            return Ok(resource);
        }
        
        [HttpGet]
        [Route("string")]
        public async Task<String> getString()
        {
            var logbookSet = await _context.Logbooks.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            String data;
            if (logbookSet == null)
            {
                data = "vacio";
            }
            else
            {
                data = "algo";
            }
            return data;
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
            var logbookSet = await _context.Logbooks.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (logbookSet == null)
            {
                logbook.SetId(1);
            }
            else
            { 
                logbook.SetId(logbookSet.Id + 1);
            }
            patient.SetLogBookId(logbook.Id);
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