using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class DetallesPacienteServicio
    {
        //atributos: Servicio, FechaRegistro.
        public string Servicio { get; set; }
        public string FechaRegistro { get; set; }

        //constructor vacio
        public DetallesPacienteServicio()
        {
        }
    }
}