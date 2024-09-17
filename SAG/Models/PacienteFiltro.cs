using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class PacienteFiltro
    {
        //atributos: IdPaciente, NumeroExpediente, FechaNacimiento, CURP, ApellidoPaterno, ApellidoMaterno, Nombres, Edad, Cama, Area, Servicio AS S1 (Recupera el más reciente), EstadoSalud, Diagnostico (Quiero que los regrese asi: Inflamacion + Colesterol elevado + Diabetes), FechaIngreso, Dias 
        public int IdPaciente { get; set; }
        public string NumeroExpediente { get; set; }
        public dynamic FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Cama { get; set; }
        public string Area { get; set; }
        public string S1 { get; set; }
        public string EstadoSalud { get; set; }
        public string Diagnostico { get; set; }
        public dynamic FechaIngreso { get; set; }
        public int Dias { get; set; }

        //constructor vacio
        public PacienteFiltro()
        {
        }

    }
}