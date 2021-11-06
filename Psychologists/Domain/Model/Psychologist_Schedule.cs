using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Psychologists.Domain.Model
{
    public class Psychologist_Schedule
    {
        //Propierties
        public int Id { get; set; }

        //RetaionShips
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }

        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }

    }
}
