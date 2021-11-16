using System;
namespace PsychoHelp_API.patients.Resources
{
    public class PatientResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public string Img { get; set; }
    }
}