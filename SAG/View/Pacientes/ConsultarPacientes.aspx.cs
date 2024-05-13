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
    public partial class ConsultarPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object ConsultarPacientesSAG()
        {
            ApiRespuesta respuesta = new ApiRespuesta();
            ControllerPaciente controllerPaciente = new ControllerPaciente();
            List <ConsuPacien> lista = new List<ConsuPacien>();

            try
            {
                respuesta.Action = "Consultar Pacientes";
                respuesta.Result = "1";
                respuesta.Message = "Consulta Correcta";
                //respuesta.Data = controllerPaciente.RecuperarPacientes();
                lista = controllerPaciente.RecuperarPacientes();
                respuesta.DataList = null;

                JavaScriptSerializer js = new JavaScriptSerializer();
                //return js.Serialize(respuesta);
                return lista;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}