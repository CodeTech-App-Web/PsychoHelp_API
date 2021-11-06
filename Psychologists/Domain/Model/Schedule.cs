using System;
using System.Collections.Generic;

namespace PsychoHelp_API.Psychologists.Domain.Model
{
    public class Schedule
    {
        //Propierties
        public int Id { get; set; }
        public string Time { get; set; }

        //RelationShips
        public IList<Psychologist_Schedule> Psychologist_Schedules { get; set; } = new List<Psychologist_Schedule>();
    }
}