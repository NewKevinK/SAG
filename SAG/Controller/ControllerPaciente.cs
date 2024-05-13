using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SAG.Models;

namespace SAG.Controller
{
    public partial class ControllerPaciente
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public dynamic InsertarPaciente(Paciente P, PacienteResponsable PR)
        {

            try
            {
                using (SqlCommand cmd = new SqlCommand("dbo.RegistrarPaciente", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombres", System.Data.SqlDbType.NVarChar).Value = P.Nombres;
                    cmd.Parameters.Add("@ApellidoPaterno", System.Data.SqlDbType.NVarChar).Value = P.ApellidoPaterno;
                    cmd.Parameters.Add("@ApellidoMaterno", System.Data.SqlDbType.NVarChar).Value = P.ApellidoMaterno;
                    cmd.Parameters.Add("@CURP", System.Data.SqlDbType.NVarChar).Value = P.CURP;
                    cmd.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = P.FechaNacimiento;
                    cmd.Parameters.Add("@Sexo", System.Data.SqlDbType.NVarChar).Value = P.Sexo;
                    cmd.Parameters.Add("@EntidadNacimiento", System.Data.SqlDbType.NVarChar).Value = P.EntidadNacimiento;
                    cmd.Parameters.Add("@Afiliacion", System.Data.SqlDbType.NVarChar).Value = P.Afiliacion;
                    cmd.Parameters.Add("@NumeroAfiliacion", System.Data.SqlDbType.NVarChar).Value = P.NumeroAfiliacion;
                    cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar).Value = P.Direccion;
                    cmd.Parameters.Add("@NumeroExterior", System.Data.SqlDbType.NVarChar).Value = P.NumeroExterior;
                    cmd.Parameters.Add("@NumeroInterior", System.Data.SqlDbType.NVarChar).Value = P.NumeroInterior;
                    cmd.Parameters.Add("@Colonia", System.Data.SqlDbType.NVarChar).Value = P.Colonia;
                    cmd.Parameters.Add("@CodigoPostal", System.Data.SqlDbType.NVarChar).Value = P.CodigoPostal;
                    cmd.Parameters.Add("@Municipio", System.Data.SqlDbType.NVarChar).Value = P.Municipio;
                    cmd.Parameters.Add("@Estado", System.Data.SqlDbType.NVarChar).Value = P.Estado;
                    cmd.Parameters.Add("@Pais", System.Data.SqlDbType.NVarChar).Value = P.Pais;
                    cmd.Parameters.Add("@TelefonoTrabajo", System.Data.SqlDbType.NVarChar).Value = P.TelefonoTrabajo;
                    cmd.Parameters.Add("@TelefonoCasa", System.Data.SqlDbType.NVarChar).Value = P.TelefonoCasa;
                    cmd.Parameters.Add("@TelefonoCelular", System.Data.SqlDbType.NVarChar).Value = P.TelefonoCelular;
                    cmd.Parameters.Add("@CorreoElectronico", System.Data.SqlDbType.NVarChar).Value = P.CorreoElectronico;
                    cmd.Parameters.Add("@Ocupacion", System.Data.SqlDbType.NVarChar).Value = P.Ocupacion;
                    cmd.Parameters.Add("@FechaRegistro", System.Data.SqlDbType.DateTime).Value = P.FechaRegistro;
                    cmd.Parameters.Add("@FechaModificacion", System.Data.SqlDbType.DateTime).Value = P.FechaModificacion;

                    cmd.Parameters.Add("@NombresResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Nombres;
                    cmd.Parameters.Add("@ApellidoPaternoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.ApellidoPaterno;
                    cmd.Parameters.Add("@ApellidoMaternoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.ApellidoMaterno;
                    cmd.Parameters.Add("@ParentescoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Parentesco;
                    cmd.Parameters.Add("@DomicilioResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Domicilio;
                    cmd.Parameters.Add("@TelefonoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Telefono;

                    SqlDataReader dr = cmd.ExecuteReader();

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

        public dynamic UpdatePaciente(Paciente P, PacienteResponsable PR)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = P.IdPaciente;
                    cmd.Parameters.Add("@Nombres", System.Data.SqlDbType.NVarChar).Value = P.Nombres;
                    cmd.Parameters.Add("@ApellidoPaterno", System.Data.SqlDbType.NVarChar).Value = P.ApellidoPaterno;
                    cmd.Parameters.Add("@ApellidoMaterno", System.Data.SqlDbType.NVarChar).Value = P.ApellidoMaterno;
                    cmd.Parameters.Add("@CURP", System.Data.SqlDbType.NVarChar).Value = P.CURP;
                    cmd.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = P.FechaNacimiento;
                    cmd.Parameters.Add("@Sexo", System.Data.SqlDbType.NVarChar).Value = P.Sexo;
                    cmd.Parameters.Add("@EntidadNacimiento", System.Data.SqlDbType.NVarChar).Value = P.EntidadNacimiento;
                    cmd.Parameters.Add("@Afiliacion", System.Data.SqlDbType.NVarChar).Value = P.Afiliacion;
                    cmd.Parameters.Add("@NumeroAfiliacion", System.Data.SqlDbType.NVarChar).Value = P.NumeroAfiliacion;
                    
                    cmd.Parameters.Add("@FechaModificacion", System.Data.SqlDbType.DateTime).Value = P.FechaModificacion;

                    cmd.Parameters.Add("@NombresResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Nombres;
                    cmd.Parameters.Add("@ApellidoPaternoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.ApellidoPaterno;
                    cmd.Parameters.Add("@ApellidoMaternoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.ApellidoMaterno;
                    cmd.Parameters.Add("@ParentescoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Parentesco;
                    cmd.Parameters.Add("@DomicilioResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Domicilio;
                    cmd.Parameters.Add("@TelefonoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Telefono;


                    cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }

        }

        public dynamic RecuperarPaciente(int IdPaciente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("dbo.RecuperarPaciente", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;

                    List<PacienteModificar> lista = new List<PacienteModificar>();
                    SqlDataReader dr = cmd.ExecuteReader();

                    
                    while (dr.Read())
                    {
                        PacienteModificar PM = new PacienteModificar();
                        PM.IdPaciente = Convert.ToInt32(dr["IdPaciente"]);
                        PM.Nombres = dr["Nombres"].ToString();
                        PM.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                        PM.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                        PM.CURP = dr["CURP"].ToString();
                        //PM.FechaNacimiento = dr["FechaNacimiento"].ToString();
                        //PM.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                        PM.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyyy-MM-dd");
                        PM.Sexo = dr["Sexo"].ToString();
                        PM.EntidadNacimiento = dr["EntidadNacimiento"].ToString();
                        PM.Afiliacion = dr["Afiliacion"].ToString();
                        PM.NumeroAfiliacion = dr["NumeroAfiliacion"].ToString();
                        //PM.NumeroAfiliacion = Convert.ToInt32(dr["NumeroAfiliacion"]);
                        PM.Direccion = dr["Direccion"].ToString();
                        PM.NumeroExterior = dr["NumeroExterior"].ToString();
                        PM.NumeroInterior = dr["NumeroInterior"].ToString();
                        PM.Colonia = dr["Colonia"].ToString();
                        PM.CodigoPostal = dr["CodigoPostal"].ToString();
                        PM.Municipio = dr["Municipio"].ToString();
                        PM.Estado = dr["Estado"].ToString();
                        PM.Pais = dr["Pais"].ToString();
                        PM.TelefonoTrabajo = dr["TelefonoTrabajo"].ToString();
                        PM.TelefonoCasa = dr["TelefonoCasa"].ToString();
                        PM.TelefonoCelular = dr["TelefonoCelular"].ToString();
                        PM.CorreoElectronico = dr["CorreoElectronico"].ToString();
                        PM.Ocupacion = dr["Ocupacion"].ToString();
                        PM.NombresResponsable = dr["NombresResponsable"].ToString();
                        PM.ApellidoPaternoResponsable = dr["ApellidoPaternoResponsable"].ToString();
                        PM.ApellidoMaternoResponsable = dr["ApellidoMaternoResponsable"].ToString();
                        PM.ParentescoResponsable = dr["ParentescoResponsable"].ToString();
                        PM.DomicilioResponsable = dr["DomicilioResponsable"].ToString();
                        PM.TelefonoResponsable = dr["TelefonoResponsable"].ToString();

                        
                        lista.Add(PM);
                    }




                    return lista;
                }


            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        public dynamic RecuperarPacientes()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("dbo.RecuperarInfoPacientes", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<ConsuPacien> lista = new List<ConsuPacien>();
                    //lo que recupere lo ira guardando en la lista
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        
                        ConsuPacien CP = new ConsuPacien();
                        CP.IdPaciente = Convert.ToInt32(dr["IdPaciente"]);
                        //CP.FechaRegistro = dr["FechaRegistro"].ToString();
                        CP.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyyy-MM-dd HH:mm:ss");
                        //puede ser yyyy-MM-dd 

                        CP.CURP = dr["CURP"].ToString();
                        CP.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                        CP.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                        CP.Nombres = dr["Nombres"].ToString();
                        CP.Diagnostico = dr["Diagnostico"].ToString();
                        lista.Add(CP);
                    }  
                    con.Close();
                    return lista;
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