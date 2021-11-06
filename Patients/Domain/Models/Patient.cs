using System;

namespace PsychoHelp_API.patients.Domain.Models
{
    public class Patient
    {
        // Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public string Img { get; set; }
        // Relationships
        public int LogBookId { get; set; }
        public Logbook Logbook { get; set; }

        public void SetLogBook(Logbook logbook)
        {
            this.Logbook = logbook;
        }
    }
}