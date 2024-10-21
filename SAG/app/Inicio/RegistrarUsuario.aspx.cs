using SAG.AppCode;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace SAG.app.Inicio
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static dynamic RegistrarUsuar(string Nombres, string Usuario, string Password)
        {
            ControllerUsuario controllerUsuario = new ControllerUsuario();
            ApiRespuesta apiRespuesta = new ApiRespuesta();
            
            try
            {
                apiRespuesta = controllerUsuario.InsertUsuario(Nombres, Usuario, Password);
                return apiRespuesta;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

    }
}