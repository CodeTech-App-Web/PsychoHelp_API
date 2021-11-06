﻿using PsychoHelp_API.Psychologists.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Psychologists.Resources
{
    public class PsychologistResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Specialization { get; set; }
        public string Formation { get; set; }
        public string About { get; set; }
        public bool Active { get; set; }
        public bool New { get; set; }
        public string Img { get; set; }
        public int Cmp { get; set; }
        // public EGenre Genre { get; set; }
        // public ESessionType SessionType { get; set; }
    }
}