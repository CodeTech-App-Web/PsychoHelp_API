namespace PsychoHelp_API.patients.Domain.Models
{
    public class Logbook
    {
        // Properties
        public int Id { get; set; }
        public string LogBookName { get; set; }
        public string PublicHistory { get; set; }
        public string ConsultationReason { get; set; }
        // Relationships
        public Patient Patient { get; set; }
        
        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}