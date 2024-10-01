using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class Paciente
    {

       

        public int IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CURP { get; set; }
        public dynamic FechaNacimiento { get; set; } //antes DateTime
        public string Sexo { get; set; }
        public string EntidadNacimiento { get; set; }
        public string Afiliacion { get; set; }
        public string NumeroAfiliacion { get; set; }

        public string Direccion { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoCelular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Ocupacion { get; set; }


        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int NumeroExpediente { get; set; }

        //constructor vacio
        public Paciente()
        {
        }

        //constructor con parametros
        public Paciente(int idPaciente, string nombres, string apellidoPaterno, string apellidoMaterno, string cURP, dynamic fechaNacimiento, string sexo, string entidadNacimiento, string afiliacion, string numeroAfiliacion, DateTime fechaRegistro, DateTime fechaModificacion, int numeroExpediente)
        {
            IdPaciente = idPaciente;
            Nombres = nombres;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            CURP = cURP;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
            EntidadNacimiento = entidadNacimiento;
            Afiliacion = afiliacion;
            NumeroAfiliacion = numeroAfiliacion;
            FechaRegistro = fechaRegistro;
            FechaModificacion = fechaModificacion;
            NumeroExpediente = numeroExpediente;
        }
    }



}