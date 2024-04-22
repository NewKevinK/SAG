using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using SAG.Models;
using SAG.Controller;

namespace SAG.View.Pacientes
{
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /*public static void InsertarPaciente()
        {
            Models.Paciente paciente = new Models.Paciente();
            App_Code.Paciente pac = new App_Code.Paciente();
            try
            {
                paciente.Nombres = "Juan";
                paciente.ApellidoPaterno = "Perez";
                paciente.ApellidoMaterno = "Gomez";
                paciente.CURP = "PEGOJU";
                paciente.FechaNacimiento = DateTime.Now;
                paciente.Sexo = "M";
                paciente.EntidadNacimiento = "CDMX";
                paciente.Afiliacion = "IMSS";
                paciente.NumeroAfiliacion = "123456789";
                paciente.FechaRegistro = DateTime.Now;
                paciente.FechaModificacion = DateTime.Now;
                paciente.NumeroExpediente = 1;
                pac.InsertarPaciente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        [WebMethod]
        public static void InsertarPaciente(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string CURP, DateTime FechaNacimiento, string Sexo, string EntidadNacimiento, string Afiliacion, string NumeroAfiliacion, DateTime FechaRegistro, DateTime FechaModificacion, int NumeroExpediente)
        {
            Models.Paciente paciente = new Models.Paciente();
            
            
            try
            {
                paciente.Nombres = Nombres;
                paciente.ApellidoPaterno = ApellidoPaterno;
                paciente.ApellidoMaterno = ApellidoMaterno;
                paciente.CURP = CURP;
                paciente.FechaNacimiento = FechaNacimiento;
                paciente.Sexo = Sexo;
                paciente.EntidadNacimiento = EntidadNacimiento;
                paciente.Afiliacion = Afiliacion;
                paciente.NumeroAfiliacion = NumeroAfiliacion;
                paciente.FechaRegistro = FechaRegistro;
                paciente.FechaModificacion = FechaModificacion;
                paciente.NumeroExpediente = NumeroExpediente;
                //paciente.InsertarPaciente();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   


        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            //InsertarPaciente();
        }   

    }
}