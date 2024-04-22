using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using SAG.Models;

namespace SAG.AppCode
{
    
    public partial class ACPaciente
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);



        public dynamic InsertarPaciente()
        {
            Models.Paciente paciente = new Models.Paciente();

            try
            {
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = paciente.Nombres;
                    cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.NVarChar).Value = paciente.ApellidoPaterno;
                    cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.NVarChar).Value = paciente.ApellidoMaterno;
                    cmd.Parameters.Add("@CURP", SqlDbType.NVarChar).Value = paciente.CURP;
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = paciente.FechaNacimiento;
                    cmd.Parameters.Add("@Sexo", SqlDbType.NVarChar).Value = paciente.Sexo;
                    cmd.Parameters.Add("@EntidadNacimiento", SqlDbType.NVarChar).Value = paciente.EntidadNacimiento;
                    cmd.Parameters.Add("@Afiliacion", SqlDbType.NVarChar).Value = paciente.Afiliacion;
                    cmd.Parameters.Add("@NumeroAfiliacion", SqlDbType.NVarChar).Value = paciente.NumeroAfiliacion;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = paciente.FechaRegistro;
                    cmd.Parameters.Add("@FechaModificacion", SqlDbType.DateTime).Value = paciente.FechaModificacion;
                    cmd.Parameters.Add("@NumeroExpediente", SqlDbType.Int).Value = paciente.NumeroExpediente;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }
    }

    
    

}