using System.ComponentModel.DataAnnotations;

namespace PsychoHelp_API.Psychologists.Resources
{
    public class SaveScheduleResource
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Time { get; set; }
    }
}