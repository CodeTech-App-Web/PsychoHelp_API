using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Domain.Models
{
    public class Tag
    {
        // Properties
        public int Id { get; set; }
        public string Text { get; set; }

        // Relationships
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}
