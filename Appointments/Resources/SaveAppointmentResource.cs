using System;
using System.ComponentModel.DataAnnotations;

namespace PsychoHelp_API.Appointments.Resources
{
    public class SaveAppointmentResource
    {
        [Required]
        public int PatientId { get; set; }
        
        [Required]
        public int PsychoId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string PsychoNotes { get; set; }
        
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ScheduleDate { get; set; }
        
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }
    }
}