using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Resources
{
    public class SaveTagResource
    { 
        [Required]
        public string Title { get; set; }
        
        [Required]
        public int PublicationId { get; set; }
    }
}
