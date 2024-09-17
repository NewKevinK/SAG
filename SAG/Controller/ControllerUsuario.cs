using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SAG.Models;


namespace SAG.Controller
{
    public class ControllerUsuario
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public dynamic InsertUsuario(string Nombres, string Usuario, string Password)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
                using (SqlCommand cmd = new SqlCommand("dbo.RegistrarUsuario", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();
                    cmd.Parameters.Add("@Nombres", System.Data.SqlDbType.VarChar).Value = Nombres;
                    cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar).Value = Usuario;
                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = hashedPassword;
                    var messageParam = cmd.Parameters.Add("@Message", System.Data.SqlDbType.NVarChar, 100);
                    messageParam.Direction = System.Data.ParameterDirection.Output;
                    var resultParam = cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int);
                    resultParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    apiRespuesta.Message = (string)messageParam.Value;
                    apiRespuesta.Result = (int)resultParam.Value;
                    con.Close();
                    return apiRespuesta;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }
    }
}