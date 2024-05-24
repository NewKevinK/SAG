using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class DetallesPaciente
    {
        //atributos: TipoAtencion, ApellidoPaterno, ApellidoMaterno, Nombres, Nacionalidad, CURP, NumeroExpediente, FechaNacimiento, Edad, Sexo, FechaAdmision, FechaModificacion, Ambulancia.
        public string TipoAtencion { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Nacionalidad { get; set; }
        public string CURP { get; set; }
        public string NumeroExpediente { get; set; }
        public string FechaNacimiento { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string FechaAdmision { get; set; }
        public string FechaModificacion { get; set; }
        public string Ambulancia { get; set; }
        //atributos: EstadoSalud, FechaIngreso, Cama, Area, Diagnostico, TipoSeguro, Folio, EstadoPaciente, FechaAlta, FechaEgreso, MotivoEgreso, SondaInstalada, FechaSondaInstalacion, FechaCirugia, CirugiaProgramada, Procedimiento, ObservacionCirugia.
        public string EstadoSalud { get; set; }
        public string FechaIngreso { get; set; }

        public string Cama { get; set; }
        public string Area { get; set; }
        public string Diagnostico { get; set; }
        public string TipoSeguro { get; set; }
        public string Folio { get; set; }
        public string EstadoPaciente { get; set; }
        public string FechaAlta { get; set; }
        public string FechaEgreso { get; set; }
        public string MotivoEgreso { get; set; }
        public string SondaInstalada { get; set; }
        public string FechaSondaInstalacion { get; set; }
        public string FechaCirugia { get; set; }
        public string CirugiaProgramada { get; set; }
        public string Procedimiento { get; set; }
        public string ObservacionCirugia { get; set; }


        public string FechaRegistro { get; set; }
        public string Servicio { get; set; }

        //constructor vacio
        public DetallesPaciente()
        {
        }

        public DetallesPaciente(string fechaRegistro, string servicio)
        {
            FechaRegistro = fechaRegistro;
            Servicio = servicio;
        }

    }
}