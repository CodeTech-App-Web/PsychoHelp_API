using System;

namespace PsychoHelp_API.Publications.Domain.Models
{
    public class Publication
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}