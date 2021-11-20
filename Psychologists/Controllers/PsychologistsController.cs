using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PsychoHelp_API.Psychologists.Domain.Model;
using PsychoHelp_API.Psychologists.Domain.Services;
using PsychoHelp_API.Psychologists.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychoHelp_API.Extensions;
using PsychoHelp_API.Persistence.Contexts;
using PsychoHelp_API.Psychologists.Domain.Services.Communication;
using PsychoHelp_API.Psychologists.Persistence.Repositories;

namespace PsychoHelp_API.Psychologists.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PsychologistsController : ControllerBase
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public PsychologistsController(IPsychologistService psychologistService, IMapper mapper, AppDbContext context)
        {
            _psychologistService = psychologistService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PsychologistResource>> GetAllAsync()
        {
            var psychologists = await _psychologistService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Psychologist>, IEnumerable<PsychologistResource>>(psychologists);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdAsync(int id)
        {
            var psychologist = await _psychologistService.GetByIdAsync(id);
            if (psychologist == null)
                return NotFound();
            var resource = _mapper.Map<Psychologist, PsychologistResource>(psychologist);
            return Ok(resource);
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

        // [HttpGet("{PsychologistId}")]
        // public async Task<IEnumerable<ScheduleRepository>> GetSchedulesFromPsycho([FromRoute] int PsychologistId)
        // {
        //     
        // }
       
        
        
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

        [HttpPost("{Id}/{ScheduleId}")]
        public async Task<IActionResult> AddSchedule([FromRoute] int Id, [FromRoute] int ScheduleId)
        {
            var psychologist = await _context.Psychologists.Include(p => p.Schedules)
                .SingleAsync(p => p.Id == Id);
        
            var schedule = await _context.Schedules.SingleAsync(s => s.Id == ScheduleId);
            if (psychologist == null || schedule == null)
            {
                return NotFound();
            }
            
            psychologist.Schedules.Add(schedule);
        
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        
            return Ok();
        }

        [HttpGet("schedule/{Id}")]
        public async Task<IEnumerable<ScheduleResource>> GetScheduleFromPsycho([FromRoute] int Id)
        {
            var psychologists = await _context.Psychologists.Include(d => d.Schedules)
                .FirstOrDefaultAsync(d => d.Id == Id);

            var schedules = psychologists.Schedules.ToList();
            return schedules.Select(c => new ScheduleResource
            {
                Id = c.Id,
                Time = c.Time
            });
        }

        [HttpGet("genre/{genre}")]
        public async Task<IEnumerable<PsychologistResource>> GetPsychologistsByGenre(string genre)
        {
            var psychologists = await _psychologistService.ListAsync();
            var psychologistByGenre = psychologists.Where(p => p.Genre == genre);

            return psychologistByGenre.Select(p => new PsychologistResource
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Dni = p.Dni,
                Email = p.Email,
                Password = p.Password,
                Phone = p.Phone,
                Specialization = p.Specialization,
                Formation = p.Formation,
                About = p.About,
                Active = p.Active,
                New = p.New,             
                Img = p.Img,
                Cmp = p.Cmp,
                Genre = p.Genre,
                SessionType = p.SessionType
            });
        }

        [HttpGet("sessionType/{sessionType}")]
        public async Task<IEnumerable<PsychologistResource>> GetPsychologistsBySessionType(string sessionType)
        {
            var psychologists = await _psychologistService.ListAsync();
            var psychologistBySessionType = psychologists.Where(p => p.SessionType == sessionType);

            return psychologistBySessionType.Select(p => new PsychologistResource
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Dni = p.Dni,
                Email = p.Email,
                Password = p.Password,
                Phone = p.Phone,
                Specialization = p.Specialization,
                Formation = p.Formation,
                About = p.About,
                Active = p.Active,
                New = p.New,
                Img = p.Img,
                Cmp = p.Cmp,
                Genre = p.Genre,
                SessionType = p.SessionType
            });
        }

        [HttpGet("genre/{genre}&sessionType/{sessionType}")]
        public async Task<IEnumerable<PsychologistResource>> GetPsychologistByGenreAndSessionType(string genre, string sessionType)
        {
            var psychologists = await _psychologistService.ListAsync();
            var psychologistByGenreAndSessionType = psychologists.Where(p => p.SessionType == sessionType && p.Genre == genre);

            return psychologistByGenreAndSessionType.Select(p => new PsychologistResource
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Dni = p.Dni,
                Email = p.Email,
                Password = p.Password,
                Phone = p.Phone,
                Specialization = p.Specialization,
                Formation = p.Formation,
                About = p.About,
                Active = p.Active,
                New = p.New,
                Img = p.Img,
                Cmp = p.Cmp,
                Genre = p.Genre,
                SessionType = p.SessionType
            });  

        }

        [HttpGet("name/{name}")]
        public async Task<IEnumerable<PsychologistResource>> GetPsychologistByName(string name)
        {
            // var psychologistsList = await _psychologistService.ListAsync();
            // var psychologistByName = psychologistsList.Where(p => p.Name.Contains(name));
            // Console.WriteLine(psychologistsList);
            //var psychologistByName = _context.Psychologists.;
           //if (name != "")
             var  psychologistByName = _context.Psychologists.Where(p => p.Name.Contains(name));

            return psychologistByName.Select(p => new PsychologistResource
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Dni = p.Dni,
                Email = p.Email,
                Password = p.Password,
                Phone = p.Phone,
                Specialization = p.Specialization,
                Formation = p.Formation,
                About = p.About,
                Active = p.Active,
                New = p.New,
                Img = p.Img,
                Cmp = p.Cmp,
                Genre = p.Genre,
                SessionType = p.SessionType
            });
        }
    }
}
