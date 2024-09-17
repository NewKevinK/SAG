using Newtonsoft.Json.Linq;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using BCrypt.Net;

namespace SAG.Controller
{
    public class ControllerLogin
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        public dynamic IniciarSesion(string Usuario, string Password)
        {
            
            try
            {
                
                using (SqlCommand cmd = new SqlCommand("dbo.IniciarSesionBC", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    ApiRespuesta apiRespuesta = new ApiRespuesta();
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = Usuario;

                    var messageParam = cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 100);
                    messageParam.Direction = ParameterDirection.Output;

                    var resultParam = cmd.Parameters.Add("@Result", SqlDbType.Int);
                    resultParam.Direction = ParameterDirection.Output;

                    var hashedPasswordParam = cmd.Parameters.Add("@HashedPassword", SqlDbType.NVarChar, 100);
                    hashedPasswordParam.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    string hashedPasswordFromDB = (string)(hashedPasswordParam.Value == DBNull.Value ? null : hashedPasswordParam.Value);

                    // Verificar el resultado y el mensaje
                    apiRespuesta.Message = (string)messageParam.Value;
                    apiRespuesta.Result = (int)resultParam.Value;

                    if (apiRespuesta.Result == 1 && !string.IsNullOrEmpty(hashedPasswordFromDB))
                    {
                        bool passwordMatch = BCrypt.Net.BCrypt.Verify(Password, hashedPasswordFromDB);

                        if (passwordMatch)
                        {
                            apiRespuesta.Message = "Inicio de sesión exitoso.";
                            apiRespuesta.Result = 1;
                        }
                        else
                        {
                            apiRespuesta.Message = "Contraseña incorrecta.";
                            apiRespuesta.Result = 0;
                        }
                    }
                    else if (apiRespuesta.Result == 0)
                    {
                        apiRespuesta.Message = "Usuario no encontrado.";
                    }

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