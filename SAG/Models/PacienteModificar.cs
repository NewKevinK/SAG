using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class PacienteModificar
    {
        public int IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CURP { get; set; }
        public dynamic FechaNacimiento { get; set; }
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

        public string NombresResponsable { get; set; }
        public string ApellidoPaternoResponsable { get; set; }
        public string ApellidoMaternoResponsable { get; set; }
        public string ParentescoResponsable { get; set; }
        public string DomicilioResponsable { get; set; }
        public string TelefonoResponsable { get; set; }

        public DateTime FechaModificacion { get; set; }

        public PacienteModificar()
        {

        }

        


    }
}