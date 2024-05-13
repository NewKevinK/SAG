using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class Alergia
    {
        //atributos: IdPaciente, FechaRegistro, TipoAlergia, Causante, Detalles
        public int IdPaciente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TipoAlergia { get; set; }
        public string Causante { get; set; }
        public string Detalles { get; set; }
        
        //constructor vacio
        public Alergia()
        {
        }

    }
}