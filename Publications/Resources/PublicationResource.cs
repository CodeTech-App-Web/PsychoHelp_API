using PsychoHelp_API.Psychologists.Resources;
using System;

namespace PsychoHelp_API.Publications.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Tags { get; set; }
        public DateTime CreatedAt { get; set; } 
        public PsychologistResource Psychologist { get; set; }

    }
}