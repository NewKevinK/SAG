using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class Diagnostico
    {
        //atributos: IdPaciente, FechaRegistro, NombreMedico, Diagnostico, TipoDiagnostico, Observacion.
        public int IdPaciente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreMedico { get; set; }
        public string DiagnosticoNombre { get; set; }
        public string TipoDiagnostico { get; set; }
        public string Observacion { get; set; }

        //constructor vacio
        public Diagnostico()
        {
        }
    }
}