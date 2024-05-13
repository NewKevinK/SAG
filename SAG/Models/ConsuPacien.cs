using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class ConsuPacien
    {
        //atributos: IdPaciente, FechaRegistro, CURP, ApellidoPaterno, ApellidoMaterno, Nombres, Diagnostico.
        public int IdPaciente { get; set; }
        public dynamic FechaRegistro { get; set; }
        public string CURP { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Diagnostico { get; set; }

        //constructor vacio
        public ConsuPacien()
        {
        }

    }
}