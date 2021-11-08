using System;
using System.Collections.Generic;
using PsychoHelp_API.Appointments.Domain.Models;

namespace PsychoHelp_API.Psychologists.Domain.Model
{
    public class Psychologist
    {
        //propierties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Specialization { get; set; }
        public string Formation { get; set; }
        public string About { get; set; }
        public bool Active { get; set; }
        public bool New { get; set; }
        public string Img { get; set; }
        public int Cmp { get; set; }
        public EGenre Genre { get; set; }
        public ESessionType SessionType { get; set; }

        //RelationShips
        public IList<Psychologist_Schedule> Psychologist_Schedules { get; set; } = new List<Psychologist_Schedule>();
        public IList<Appointment> Appointments { get; set; }= new List<Appointment>();
    }
}