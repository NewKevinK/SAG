using SAG.AppCode;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAG.app.Pacientes
{
    public partial class BuscarPaciente : System.Web.UI.Page
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
        public static dynamic GetPacientesFiltro(string EstadoPaciente, string Anio)
        {
            List<PacienteFiltro> lista = new List<PacienteFiltro>();
            ControllerPaciente controllerPaciente = new ControllerPaciente();
            try
            {
                lista = controllerPaciente.BuscarPacientesFiltro(EstadoPaciente, Anio);

                return lista;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static dynamic GetPacientes(int IdPaciente)
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
        public static dynamic PatchEstadoPaciente(int IdPaciente, string EstadoPaciente)
        {

            
            ControllerPaciente controllerPaciente = new ControllerPaciente();
            try
            {


                return controllerPaciente.CambiarEstadoPaciente(IdPaciente, EstadoPaciente);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


    }
}