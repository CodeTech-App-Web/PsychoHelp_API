using System;
using System.ComponentModel.DataAnnotations;

namespace PsychoHelp_API.Appointments.Resources
{
    public class UpdateAppointmentResource
    {
        [Required]
        [MaxLength(100)]
        public string PsychoNotes { get; set; }
        
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ScheduleDate { get; set; }
        
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Motive { get; set; }
        [Required]
        [MaxLength(200)]
        public string PersonalHistory { get; set; }
        [Required]
        [MaxLength(200)]
        public string TestRealized { get; set; }
        [Required]
        [MaxLength(200)]
        public string Treatment { get; set; }
    }
}