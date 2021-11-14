using PsychoHelp_API.Psychologists.Domain.Model;
using System;
using System.Collections.Generic;

namespace PsychoHelp_API.Publications.Domain.Models
{
    public class Publication
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       // public string Tags { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relationships

        public int PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }

        public IList<Tag> Tags { get; set; } = new List<Tag>();
    }
}