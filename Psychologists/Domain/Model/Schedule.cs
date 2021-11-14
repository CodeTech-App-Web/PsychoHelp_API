using System;
using System.Collections.Generic;

namespace PsychoHelp_API.Psychologists.Domain.Model
{
    public class Schedule
    {
        //Propierties
        public int Id { get; set; }
        public string Time { get; set; }
        
        //RelationShip
        public virtual ICollection<Psychologist> Psychologists { get; set; }
    }
}