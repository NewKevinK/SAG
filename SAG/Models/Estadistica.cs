using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class Estadistica
    {
        public string Fecha { get; set; }
        public int PacientesIngresados { get; set; }
        public int PacientesEgresados { get; set; }
        public int PacientesHospitalizados { get; set; }
    }
}