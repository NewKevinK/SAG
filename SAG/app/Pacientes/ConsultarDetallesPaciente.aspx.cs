using SAG.AppCode;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAG.app.Pacientes
{
    public partial class ConsultarDetallesPaciente : System.Web.UI.Page
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
        public static dynamic InsertarDiagnostico(int IdPaciente, string MedicoEncargado, string Diagnostico, string TipoDiagnostico, string Observaciones) {
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                ApiRespuesta apiRespuesta = new ApiRespuesta();

                apiRespuesta = controllerPaciente.RegistrarDiagnostico(IdPaciente, MedicoEncargado, Diagnostico, TipoDiagnostico, Observaciones);

                return apiRespuesta;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static dynamic InsertarAlergia(int IdPaciente, string TipoAlergia, string Causante, string Detalles)
        {
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                ApiRespuesta apiRespuesta = new ApiRespuesta();

                apiRespuesta = controllerPaciente.RegistrarAlergia(IdPaciente, TipoAlergia, Causante, Detalles);

                return apiRespuesta;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static dynamic InsertarServicio(int IdPaciente, string Servicio)
        {
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                ApiRespuesta apiRespuesta = new ApiRespuesta();

                apiRespuesta = controllerPaciente.RegistrarServicio(IdPaciente, Servicio);

                return apiRespuesta;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static dynamic UpdateDetallesInformacionPaciente(int IdPaciente, string TipoAtencion, string EstadoSalud, string FechaIngreso, string Cama, 
            string Area, string TipoSeguro, string Folio, string EstadoPaciente, string FechaAlta, string FechaEgreso, string MotivoEgreso, string SondaInstalada,
            string FechaSondaInstalacion, string CirugiaProgramada, string Procedimiento, string FechaCirugia, string Observaciones)

        {
            try
            {
                DetallesPaciente d = new DetallesPaciente();
                d.TipoAtencion = TipoAtencion;
                d.EstadoSalud = EstadoSalud;
                d.FechaIngreso = FechaIngreso;
                d.Cama = Cama;
                d.Area = Area;
                d.TipoSeguro = TipoSeguro;
                d.Folio = Folio;
                d.EstadoPaciente = EstadoPaciente;
                d.FechaAlta = FechaAlta;
                d.FechaEgreso = FechaEgreso;
                d.MotivoEgreso = MotivoEgreso;
                d.SondaInstalada = SondaInstalada;
                d.FechaSondaInstalacion = FechaSondaInstalacion;
                d.CirugiaProgramada = CirugiaProgramada;
                d.Procedimiento = Procedimiento;
                d.FechaCirugia = FechaCirugia;
                d.ObservacionCirugia = Observaciones;

                ControllerPaciente controllerPaciente = new ControllerPaciente();
                ApiRespuesta apiRespuesta = controllerPaciente.ModificarDetallesInformacionPaciente(IdPaciente, d);

                return apiRespuesta;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static dynamic GetDetallesPaciente(int IdPaciente)
        {
            
            List<DetallesPaciente> lista = new List<DetallesPaciente>();
            ControllerPaciente controllerPaciente = new ControllerPaciente();
            try
            {
                lista = controllerPaciente.ConsultarDetallesPaciente(IdPaciente);

                return lista;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static dynamic GetInformacionPaciente(int IdPaciente)
        {
            
            ControllerPaciente controllerPaciente = new ControllerPaciente();
            List<DetallesPaciente> lista = new List<DetallesPaciente>();
            try
            {
                //Fechas invalid
                lista = controllerPaciente.VerInformacionPaciente(IdPaciente);

                return lista;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static dynamic GetInformacionPacienteServicio(int IdPaciente)
        {

            ControllerPaciente controllerPaciente = new ControllerPaciente();
            List<DetallesPacienteServicio> lista = new List<DetallesPacienteServicio>();
            try
            {
                lista = controllerPaciente.VerInformacionPacienteServicio(IdPaciente);

                return lista;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static dynamic GetDiagnosticosPaciente(int IdPaciente)
        {

            ControllerPaciente controllerPaciente = new ControllerPaciente();
            List<Diagnostico> lista = new List<Diagnostico>();
            try
            {
                lista = controllerPaciente.VerDiagnosticosPaciente(IdPaciente);

                return lista;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static dynamic GetAlergiasPaciente(int IdPaciente)
        {

            ControllerPaciente controllerPaciente = new ControllerPaciente();
            List<Alergia> lista = new List<Alergia>();
            try
            {
                lista = controllerPaciente.VerAlergiasPaciente(IdPaciente);

                return lista;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}