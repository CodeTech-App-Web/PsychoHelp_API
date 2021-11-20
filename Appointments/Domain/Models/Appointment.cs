using System;
using PsychoHelp_API.patients.Domain.Models;
using PsychoHelp_API.Psychologists.Domain.Model;

namespace PsychoHelp_API.Appointments.Domain.Models
{
    public class Appointment
    {
        // Properties
        public int Id { get; set; }
        public string PsychoNotes { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string Motive { get; set; }
        public string PersonalHistory { get; set; }
        public string TestRealized { get; set; }
        public string Treatment { get; set; }
        
        //RelationShips
        public Patient patient { get; set; }
        public int PatientId { get; set; }
        public Psychologist psychologist { get; set; }
        public int PsychoId { get; set; }
    }
}