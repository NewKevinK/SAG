using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAG.app;
using SAG.Models;
using SAG.AppCode;

namespace SAG.app.Inicio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static dynamic LoginSAG(string Usuario, string Password)
        {
            
            ControllerLogin controllerLogin = new ControllerLogin();
            ApiRespuesta apiRespuesta = new ApiRespuesta();
            Console.WriteLine(Usuario);
            apiRespuesta = controllerLogin.IniciarSesion(Usuario, Password);
            try
            {
                if (apiRespuesta.Result == 1)
                {
                    JWT jwt = new JWT();
                    string token = jwt.GenerateJwtToken(Usuario);

                    HttpCookie jwtCookie = new HttpCookie("JWTToken", token)
                    {
                        HttpOnly = true,
                        Secure = true, 
                        Expires = DateTime.Now.AddHours(4)
                    };

                    HttpContext.Current.Response.Cookies.Add(jwtCookie);
                    return apiRespuesta;
                }
                else
                {
                    return "Usuario o contraseña incorrectos";
                }


                //return controllerLogin.IniciarSesion(Usuario, Password);
               
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


    }
}