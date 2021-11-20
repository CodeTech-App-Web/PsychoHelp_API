using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Psychologists.Resources
{
    public class SavePsychologistResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public int Dni { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Formation { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public bool New { get; set; }

        [Required]
        public string Img { get; set; }

        [Required]
        public int Cmp { get; set; }

        [Required]
        public string Genre { get; set; }
        
        [Required] 
        public string SessionType { get; set; }


    }
}
