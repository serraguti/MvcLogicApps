﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcLogicApps.Models
{
    public class Doctor
    {
        public int IdDoctor { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public int Salario { get; set; }
        public int Hospital { get; set; }
    }
}
