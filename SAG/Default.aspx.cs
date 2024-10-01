using SAG.Controller;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAG
{
    public partial class _Default : Page
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
        public static dynamic GetEstadisticaSemanalHome()
        {
            //var fechas = new List<string> { "2024-09-20", "2024-09-21", "2024-09-22", "2024-09-23", "2024-09-24", "2024-09-25", "2024-09-26" };
            //var pacientesIngresados = new List<int> { 5, 10, 8, 15, 22, 7, 9 };

            
            ControllerPaciente controllerPaciente = new ControllerPaciente();

            List<Estadistica> estadisticas = controllerPaciente.RecuperarEstadisticaSemanalHome();
            Estadistica estadistic = new Estadistica();
            // Separar fechas y número de pacientes en listas
            var fechas = new List<string>();
            var pacientesIngresados = new List<int>();

            foreach (var estadistica in estadisticas)
            {
                fechas.Add(estadistica.Fecha);
                pacientesIngresados.Add(estadistica.PacientesIngresados);
            }

            return new
            {
                dates = fechas,
                pacientesIngresados = pacientesIngresados
            };
        }

        [WebMethod]
        public static dynamic GetTablaHome()
        {
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                List<DetallesPaciente> detallesPacientes = controllerPaciente.RecuperarPacientesHome();
                return detallesPacientes;
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }

            
        }

        [WebMethod]
        public static dynamic GetEstadisticaDiariaHome()
        {
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                Estadistica estadisticas = controllerPaciente.RecuperarEstadisticaDiariaHome();
                return estadisticas;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}