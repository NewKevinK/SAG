using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using SAG.Models;
using SAG.AppCode;
using System.Web.Script.Serialization;
using System.Security.Claims;

namespace SAG.app.Pacientes
{
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Eliminar todas las sesiones
            Session.Clear();
            Session.Abandon();

            // Desactivar la caché
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetNoStore();

            // Verificar si el usuario está autenticado
            var token = HttpContext.Current.Request.Cookies["JWTToken"]?.Value;

            if (string.IsNullOrEmpty(token) || ValidateToken(token) == null)
            {
                // Si el token no es válido o no está presente, redirigir al inicio de sesión
                Response.Redirect("~/View/Inicio/Login.aspx");
            }
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var principal = JWT.GetPrincipal(token);

                if (principal == null)
                {
                    return false;
                }

                var identity = principal.Identity as ClaimsIdentity;

                if (identity == null)
                {
                    return false;
                }

                var usernameClaim = identity.FindFirst(ClaimTypes.Name);

                if (usernameClaim == null)
                {
                    return false;
                }

                var username = usernameClaim.Value;

                // Opcional: realizar más validaciones si es necesario
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        public static dynamic InsertarPaciente(string Nombres, string ApellidoPaterno, string ApellidoMaterno, string CURP, string FechaNacimiento, string Sexo, 
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