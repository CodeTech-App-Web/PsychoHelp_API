using System;

namespace PsychoHelp_API.Appointments.Resources
{
    public class AppointmentResource
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PsychoId { get; set; }
        public string PsychoNotes { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}