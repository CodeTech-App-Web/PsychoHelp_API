using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PsychoHelp_API.Appointments.Domain.Models;
using PsychoHelp_API.Appointments.Domain.Services;
using PsychoHelp_API.Appointments.Resources;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.patients.Resources;
using PsychoHelp_API.Publications.Domain.Models;
using PsychoHelp_API.Publications.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PsychoHelp_API.Appointments.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(Summary = "Retorna todos los appointments")]
        [HttpGet]
        public async Task<IEnumerable<AppointmentResource>> GetAllAsync()
        {
            var appointments = await _appointmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            return resources;
        }
        
        [SwaggerOperation(Summary = "Retorna todos los pacientes por el id del psicólogo")]
        [HttpGet("psychologist/{psychoId}")]
        public async Task<IEnumerable<PatientResource>> GetPatientsByPsychologistIdAsync(int psychoId)
        {
            var patients = await _appointmentService.GetPatientsByPsychologistIdAsync(psychoId);
            var resources = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientResource>>(patients);
            return resources;
        }
        
        [SwaggerOperation(Summary = "Retorna appointment por Id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
                return NotFound();
            var resource = _mapper.Map<Appointment, AppointmentResource>(appointment);
            return Ok(resource);
        }
        
        [SwaggerOperation(Summary = "Retorna appointments por Id de psicólogo")]
        [HttpGet("psychologists/{psychoId}")]
        public async Task<IEnumerable<AppointmentResource>> GetByPsychologistIdAsync(int psychoId)
        {
            var appointments = await _appointmentService.GetByPsychologistIdAsync(psychoId);
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            return resources;
        }
        
        [SwaggerOperation(Summary = "Retorna todos los appointments de un psicólogo y un paciente")]
        [HttpGet("psychologist/{psychoId}/patient/{patientId}")]
        public async Task<IEnumerable<AppointmentResource>> GetAppointmentByPatientsAndPsychologistIdAsync(int psychoId, int patientId)
        {
            var appointments = await _appointmentService.GetAppointmentByPatientAndPsychologistIdAsync( patientId, psychoId);
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            return resources;
        }

        [SwaggerOperation(Summary = "Crea un appointment")]
        [HttpPost]
        public async Task<IActionResult>PostAsync([FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.SaveAsync(appointment);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);
        }
        
        [SwaggerOperation(Summary = "Actualiza los datos de un appointment por ID")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var appointment = _mapper.Map<UpdateAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.UpdateAsync(id, appointment);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);
        }
        
        [SwaggerOperation(Summary = "Elimina un appointment por ID")]
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAsync(int id)
        {
            var result = await _appointmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);
        }
    }
}