using System;
using System.ComponentModel.DataAnnotations;

namespace PsychoHelp_API.Publications.Resources
{
    public class SavePublicationResource
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        // [Required]
        // [MaxLength(50)]
        // public string Tags { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; } 

        [Required]
        public int PsychologistId { get; set; }
    }
}