using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using SAG.Models;
using SAG.Controller;
using System.Web.Script.Serialization;

namespace SAG.View.Pacientes
{
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static string Consultar()
        {
            ApiRespuesta respuesta = new ApiRespuesta();
            ControllerPaciente controllerPaciente = new ControllerPaciente();

            try
            {
                respuesta.Action = "Consultar Pacientes";
                respuesta.Result = "1";
                respuesta.Message = "Consulta Correcta";
                respuesta.Data = controllerPaciente.RecuperarPacientes();
                respuesta.DataList = null;

                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(respuesta);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [WebMethod]
        public static dynamic InsertarPaciente(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string CURP, DateTime FechaNacimiento, string Sexo, 
            string EntidadNacimiento, string Afiliacion, string NumeroAfiliacion,
            string Direccion, string NumeroExterior, string NumeroInterior, string Colonia, string CodigoPostal, string Municipio, string Estado, string Pais, 
            string TelefonoTrabajo, string TelefonoCasa, string TelefonoCelular, string CorreoElectronico, string Ocupacion,
            string NombresResponsable, string ApellidoPaternoResponsable, string ApellidoMaternoResponsable, string ParentescoResponsable, string DomicilioResponsable, string TelefonoResponsable)
        {
            Models.Paciente paciente = new Models.Paciente();
            Models.PacienteResponsable responsable = new Models.PacienteResponsable();
            Models.ApiRespuesta respuestaDI = new Models.ApiRespuesta();
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
                paciente.FechaRegistro = DateTime.Now;
                paciente.FechaModificacion = DateTime.Now;

                responsable.Nombres = NombresResponsable;
                responsable.ApellidoPaterno = ApellidoPaternoResponsable;
                responsable.ApellidoMaterno = ApellidoMaternoResponsable;
                responsable.Parentesco = ParentescoResponsable;
                responsable.Domicilio = DomicilioResponsable;
                responsable.Telefono = TelefonoResponsable;


                ApiRespuesta respuesta = controllerPaciente.InsertarPaciente(paciente, responsable);
                if(respuesta.Result == 1)
                {
                    respuestaDI = controllerPaciente.InsertarPacienteDetalleInterno();

                }
                
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }   


        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            //InsertarPaciente();
        }   

    }
}