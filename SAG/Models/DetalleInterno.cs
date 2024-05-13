using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class DetalleInterno
    {
        //atributos: IdPaciente, EstadoSalud, FechaIngreso, Cama, Area, Diagnostico, Folio, EstadoPaciente, FechaAlta, FechaEgreso, MotivoEgreso, SondaInstalada, FechaSondaInstalacion.
        public int IdPaciente { get; set; }
        public string EstadoSalud { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Cama { get; set; }
        public string Area { get; set; }
        public string Diagnostico { get; set; }
        public string Folio { get; set; }
        public string EstadoPaciente { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEgreso { get; set; }
        public string MotivoEgreso { get; set; }
        public string SondaInstalada { get; set; }
        public DateTime FechaSondaInstalacion { get; set; }

        public DetalleInterno()
        {
        }

    }
}