using SAG.Controller;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAG.View.Pacientes
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static dynamic GetPaciente(int IdPaciente)
        {
            PacienteModificar pacienteModificar = new PacienteModificar();
            ApiRespuesta respuesta = new ApiRespuesta();
            List<PacienteModificar> lista = new List<PacienteModificar>();
            ControllerPaciente controllerPaciente = new ControllerPaciente();
            try
            {
                //pacienteModificar = controllerPaciente.RecuperarPaciente(IdPaciente);
                lista = controllerPaciente.RecuperarPaciente(IdPaciente);

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //return js.Serialize(respuesta);
                return lista;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static string UpdatePaciente(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string CURP, DateTime FechaNacimiento, string Sexo,
            string EntidadNacimiento, string Afiliacion, string NumeroAfiliacion,
            string Direccion, string NumeroExterior, string NumeroInterior, string Colonia, string CodigoPostal, string Municipio, string Estado, string Pais,
            string TelefonoTrabajo, string TelefonoCasa, string TelefonoCelular, string CorreoElectronico, string Ocupacion,
            string NombresResponsable, string ApellidoPaternoResponsable, string ApellidoMaternoResponsable, string ParentescoResponsable, string DomicilioResponsable, string TelefonoResponsable)
        {
            Paciente paciente = new Paciente();
            PacienteResponsable responsable = new PacienteResponsable();
            ApiRespuesta respuesta = new ApiRespuesta();
            ControllerPaciente controllerPaciente = new ControllerPaciente();

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
                paciente.Direccion = Direccion;
                paciente.NumeroExterior = NumeroExterior;
                paciente.NumeroInterior = NumeroInterior;
                paciente.Colonia = Colonia;
                paciente.CodigoPostal = CodigoPostal;
                paciente.Municipio = Municipio;
                paciente.Estado = Estado;
                paciente.Pais = Pais;
                paciente.TelefonoTrabajo = TelefonoTrabajo;
                paciente.TelefonoCasa = TelefonoCasa;
                paciente.TelefonoCelular = TelefonoCelular;
                paciente.CorreoElectronico = CorreoElectronico;
                paciente.Ocupacion = Ocupacion;
                paciente.FechaModificacion = DateTime.Now;

                responsable.Nombres = NombresResponsable;
                responsable.ApellidoPaterno = ApellidoPaternoResponsable;
                responsable.ApellidoMaterno = ApellidoMaternoResponsable;
                responsable.Parentesco = ParentescoResponsable;
                responsable.Domicilio = DomicilioResponsable;
                responsable.Telefono = TelefonoResponsable;

                respuesta.Data = controllerPaciente.UpdatePaciente(paciente, responsable);
                
                

                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(respuesta);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}