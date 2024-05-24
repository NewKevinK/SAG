using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SAG.Models;
using SAG.View.Pacientes;

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
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

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

                    var messageParam = cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 100);
                    messageParam.Direction = ParameterDirection.Output;
                    var resultParam = cmd.Parameters.Add("@Result", SqlDbType.Int);
                    resultParam.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Leer los valores de salida
                    string message = (string)messageParam.Value;
                    int result = (int)resultParam.Value;
                    apiRespuesta.Message = (string)messageParam.Value; 
                    apiRespuesta.Result = (int)resultParam.Value;

                    con.Close();
                    return apiRespuesta;

                    /*SqlDataReader dr = cmd.ExecuteReader();

                    string data = "";
                    while (dr.Read())
                    {
                        data = dr[0].ToString();
                    }
                    con.Close();

                    return data; */

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
                using (SqlCommand cmd = new SqlCommand("[dbo].[ModificarPaciente]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

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

                    cmd.Parameters.Add("@FechaModificacion", System.Data.SqlDbType.DateTime).Value = P.FechaModificacion;

                    cmd.Parameters.Add("@NombresResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Nombres;
                    cmd.Parameters.Add("@ApellidoPaternoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.ApellidoPaterno;
                    cmd.Parameters.Add("@ApellidoMaternoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.ApellidoMaterno;
                    cmd.Parameters.Add("@ParentescoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Parentesco;
                    cmd.Parameters.Add("@DomicilioResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Domicilio;
                    cmd.Parameters.Add("@TelefonoResponsable", System.Data.SqlDbType.NVarChar).Value = PR.Telefono;

                    var messageParam = cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 100);
                    messageParam.Direction = ParameterDirection.Output;
                    var resultParam = cmd.Parameters.Add("@Result", SqlDbType.Int);
                    resultParam.Direction = ParameterDirection.Output;

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

        public dynamic ConsultarDetallesPaciente(int IdPaciente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[ConsultarDetallesPaciente]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;

                    List<DetallesPaciente> lista = new List<DetallesPaciente>();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DetallesPaciente DP = new DetallesPaciente();
                        DP.TipoAtencion = dr["TipoAtencion"].ToString();
                        DP.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                        DP.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                        DP.Nombres = dr["Nombres"].ToString();
                        DP.Nacionalidad = dr["Nacionalidad"].ToString();
                        DP.CURP = dr["CURP"].ToString();
                        DP.NumeroExpediente = dr["NumeroExpediente"].ToString();
                        DP.FechaNacimiento = dr["FechaNacimiento"].ToString();
                        DP.Edad = dr["Edad"].ToString();
                        DP.Sexo = dr["Sexo"].ToString();
                        DP.FechaAdmision = dr["FechaAdmision"].ToString();
                        DP.FechaModificacion = dr["FechaModificacion"].ToString();
                        DP.Ambulancia = dr["Ambulancia"].ToString();

                        lista.Add(DP);
                    }
                    //con.Close();
                    return lista;

                }
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        public dynamic VerInformacionPaciente(int IdPaciente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[VerInformacionPaciente]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;

                    List<DetallesPaciente> lista = new List<DetallesPaciente>();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DetallesPaciente DP = new DetallesPaciente();
                        DP.EstadoSalud = dr["EstadoSalud"].ToString();
                        DP.FechaIngreso = dr["FechaIngreso"].ToString();
                        DP.Cama = dr["Cama"].ToString();
                        DP.Area = dr["Area"].ToString();
                        DP.Diagnostico = dr["Diagnostico"].ToString();
                        DP.TipoSeguro = dr["TipoSeguro"].ToString();
                        DP.Folio = dr["Folio"].ToString();
                        DP.EstadoPaciente = dr["EstadoPaciente"].ToString();
                        DP.FechaAlta = dr["FechaAlta"].ToString();
                        DP.FechaEgreso = dr["FechaEgreso"].ToString();
                        DP.MotivoEgreso = dr["MotivoEgreso"].ToString();
                        DP.SondaInstalada = dr["SondaInstalada"].ToString();
                        DP.FechaSondaInstalacion = dr["FechaSondaInstalacion"].ToString();
                        DP.FechaCirugia = dr["FechaCirugia"].ToString();
                        DP.CirugiaProgramada = dr["CirugiaProgramada"].ToString();
                        DP.Procedimiento = dr["Procedimiento"].ToString();
                        DP.ObservacionCirugia = dr["ObservacionCirugia"].ToString();

                        lista.Add(DP);
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

        public dynamic VerInformacionPacienteServicio(int IdPaciente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[VerInformacionPacienteServicio]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;

                    List<DetallesPacienteServicio> lista = new List<DetallesPacienteServicio>();
                    
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DetallesPacienteServicio DP = new DetallesPacienteServicio();
                        DP.Servicio = dr["Servicio"].ToString();
                        DP.FechaRegistro = dr["FechaRegistro"].ToString();



                        lista.Add(DP);
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

        public dynamic VerDiagnosticosPaciente(int IdPaciente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[VerDiagnosticos]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;

                    List<Diagnostico> lista = new List<Diagnostico>();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Diagnostico D = new Diagnostico();
                        D.FechaRegistro = dr["FechaRegistro"].ToString();
                        D.NombreMedico = dr["NombreMedico"].ToString();
                        D.DiagnosticoNombre = dr["Diagnostico"].ToString();
                        D.TipoDiagnostico = dr["TipoDiagnostico"].ToString();
                        D.Observacion = dr["Observacion"].ToString();
                        lista.Add(D);

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

        public dynamic VerAlergiasPaciente(int IdPaciente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[VerAlergias]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;

                    List<Alergia> lista = new List<Alergia>();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Alergia A = new Alergia();
                        A.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyyy-MM-dd");
                        A.TipoAlergia = dr["TipoAlergia"].ToString();
                        A.Causante = dr["Causante"].ToString();
                        A.Detalles = dr["Detalles"].ToString();

                        lista.Add(A);

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



        public dynamic PdfListaPacientesHopitalizados()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    
                    List<PacienteOficio> lista = new List<PacienteOficio>();
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PacienteOficio PO = new PacienteOficio();
                        PO.ID = Convert.ToInt32(dr["ID"]);
                        PO.NoExp = dr["NoExp"].ToString();
                        PO.FDN = Convert.ToDateTime(dr["FDN"]).ToString("yyyy-MM-dd HH:mm:ss");
                        PO.CURP = dr["CURP"].ToString();
                        PO.ApellidoP = dr["ApellidoP"].ToString();
                        PO.ApellidoM = dr["ApellidoM"].ToString();
                        PO.Nombres = dr["Nombres"].ToString();
                        PO.Edad = Convert.ToInt32(dr["Edad"]);
                        PO.Cama = dr["Cama"].ToString();
                        PO.Area = dr["Area"].ToString();
                        PO.Servicio1 = dr["Servicio1"].ToString();
                        PO.Servicio2 = dr["Servicio2"].ToString();
                        PO.EdoSalud = dr["EdoSalud"].ToString();
                        PO.Diagnostico = dr["Diagnostico"].ToString() ;
                        PO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyyy-MM-dd HH:mm:ss");
                        PO.DiasInternado = Convert.ToInt32(dr["DiasInternado"]);

                        lista.Add(PO);
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