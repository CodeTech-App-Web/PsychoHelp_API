using System.ComponentModel.DataAnnotations;

namespace PsychoHelp_API.patients.Resources
{
    public class SaveLogBookResource
    {
        public SaveLogBookResource()
        {
            LogBookName = "Name";
            PublicHistory = "Public History";
            ConsultationReason = " ";
        }

        [Required]
        [MaxLength(50)]
        public string LogBookName { get; set; }
        [Required]
        [MaxLength(300)]
        public string PublicHistory { get; set; }
        [Required]
        [MaxLength(300)]
        public string ConsultationReason { get; set; }
    }
}