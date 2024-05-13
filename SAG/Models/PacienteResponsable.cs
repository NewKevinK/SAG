using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class PacienteResponsable
    {
        
        public int IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Parentesco { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public string Paciente { get; set; }

        //crea contrustur y constructor vacio
        public PacienteResponsable()
        {
        }

        public PacienteResponsable(int idPaciente, string nombres, string apellidoPaterno, string apellidoMaterno, string parentesco, string domicilio, string telefono, string tipo, string paciente)
        {
            IdPaciente = idPaciente;
            Nombres = nombres;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Parentesco = parentesco;
            Domicilio = domicilio;
            Telefono = telefono;
            Tipo = tipo;
            Paciente = paciente;
        }

    }
}