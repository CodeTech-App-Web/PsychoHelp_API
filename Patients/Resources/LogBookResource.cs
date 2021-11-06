using PsychoHelp_API.patients.Domain.Models;

namespace PsychoHelp_API.patients.Resources
{
    public class LogBookResource
    {
        public int Id { get; set; }
        public string LogBookName { get; set; }
        public string PublicHistory { get; set; }
        public string ConsultationReason { get; set; }
        public Patient Patient { get; set; }
    }
}