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
    public partial class ConsultarDetallesPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetDetallesPaciente(string IdPaciente)
        {
            ApiRespuesta respuesta = new ApiRespuesta();
            try
            {
                respuesta.Action = "GetDetallesPaciente";
                respuesta.Result = "1";
                respuesta.Message = "Consulta Correcta";
                //respuesta.Data = controllerPaciente.RecuperarPacientes();
                respuesta.DataList = null;

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