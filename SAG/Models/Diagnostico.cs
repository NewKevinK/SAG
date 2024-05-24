using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class Diagnostico
    {
        //atributos: FechaRegistro, NombreMedico, Diagnostico, TipoDiagnostico, Observacion.
        
        public string FechaRegistro { get; set; }
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