using SAG.Controller;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAG.View.Pacientes
{
    public partial class BuscarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


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
        public static dynamic PatchEstadoPaciente(int IdPaciente)
        {

            
            ControllerPaciente controllerPaciente = new ControllerPaciente();
            try
            {


                return controllerPaciente.CambiarEstadoPaciente(IdPaciente);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


    }
}