using Newtonsoft.Json.Linq;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace SAG.Controller
{
    public class ControllerLogin
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        public dynamic IniciarSesion(string Usuario, string Password)
        {
            try
            {
                
                using (SqlCommand cmd = new SqlCommand("dbo.IniciarSesion", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.NVarChar).Value = Usuario;
                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar).Value = Password;
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    //convertir el datareader a string
                    string data = "";
                    while (dr.Read())
                    {
                        data = dr[0].ToString();
                    }

                    

                    

                    con.Close();

                    return data;
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