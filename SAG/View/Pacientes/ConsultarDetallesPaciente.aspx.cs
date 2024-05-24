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