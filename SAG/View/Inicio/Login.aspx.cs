using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAG.View;
using SAG.Models;
using SAG.Controller;

namespace SAG.View.Inicio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //al dar clic en el boton de login se redirecciona a la pagina de inicio
            //Response.Redirect("~/View/RegistrarPaciente.aspx");

        }

        [WebMethod]
        public static string LoginSAG(string Usuario, string Password)
        {
            ApiRespuesta respuesta = new ApiRespuesta();
            ControllerLogin controllerLogin = new ControllerLogin();
            
            
            try
            {
                
                respuesta.Action = "Inicio de Sesion";
                respuesta.Result = "1";
                respuesta.Message = "Inicio Correcto";
                respuesta.Data = controllerLogin.IniciarSesion(Usuario, Password);
                respuesta.DataList = null;

                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(respuesta);

               

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


    }
}