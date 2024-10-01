using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;
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
                    //cmd.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = P.FechaNacimiento;
                    cmd.Parameters.AddWithValue("@FechaNacimiento", P.FechaNacimiento == null ? (object)DBNull.Value : P.FechaNacimiento);
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

        public dynamic InsertarPacienteDetalleInterno()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[RegistrarPacienteDetalleInterno]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

                    
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
                        PM.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyyy-MM-dd");
                        PM.Sexo = dr["Sexo"].ToString();
                        PM.EntidadNacimiento = dr["EntidadNacimiento"].ToString();
                        PM.Afiliacion = dr["Afiliacion"].ToString();
                        PM.NumeroAfiliacion = dr["NumeroAfiliacion"].ToString();
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
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ConsuPacien CP = new ConsuPacien();
                        CP.IdPaciente = Convert.ToInt32(dr["IdPaciente"]);
                        CP.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyyy-MM-dd HH:mm:ss");
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
                        DP.FechaNacimiento = dr["FechaNacimiento"].ToString();
                        DP.Edad = dr["Edad"].ToString();
                        DP.Sexo = dr["Sexo"].ToString();
                        
                        DP.FechaAdmision = dr["FechaAdmision"].ToString();
                        DP.FechaModificacion = dr["FechaModificacion"].ToString();

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
                        DP.FechaIngreso = dr["FechaIngreso"] != DBNull.Value ? Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyyy-MM-dd") : null;
                        DP.Cama = dr["Cama"].ToString();
                        DP.Area = dr["Area"].ToString();
                        DP.Diagnostico = dr["Diagnostico"].ToString();
                        DP.TipoSeguro = dr["TipoSeguro"].ToString();
                        DP.Folio = dr["Folio"].ToString();
                        DP.EstadoPaciente = dr["EstadoPaciente"].ToString(); 
                        DP.FechaAlta = dr["FechaAlta"] != DBNull.Value ? Convert.ToDateTime(dr["FechaAlta"]).ToString("yyyy-MM-dd") : null;
                        DP.FechaEgreso = dr["FechaEgreso"] != DBNull.Value ? Convert.ToDateTime(dr["FechaEgreso"]).ToString("yyyy-MM-dd") : null;

                        DP.MotivoEgreso = dr["MotivoEgreso"].ToString();
                        DP.SondaInstalada = dr["SondaInstalada"].ToString();
                        DP.FechaSondaInstalacion = dr["FechaSondaInstalacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaSondaInstalacion"]).ToString("yyyy-MM-dd") : null;
                        //DP.FechaCirugia = Convert.ToDateTime(dr["FechaCirugia"]).ToString("yyyy-MM-dd");
                        DP.FechaCirugia = dr["FechaCirugia"] != DBNull.Value ? Convert.ToDateTime(dr["FechaCirugia"]).ToString("yyyy-MM-dd") : null;
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
                        A.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyyy-MM-dd HH:mm:ss");
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

        public dynamic BuscarPacientesFiltro(string EstadoPaciente, string Año)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[BuscarPacientesFiltro]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    if (Año != "")
                    {
                        cmd.Parameters.Add("@EstadoPaciente", System.Data.SqlDbType.NVarChar).Value = EstadoPaciente;
                        cmd.Parameters.Add("@Año", System.Data.SqlDbType.Int).Value = Año;
                    }
                    else
                    {
                        cmd.Parameters.Add("@EstadoPaciente", System.Data.SqlDbType.NVarChar).Value = EstadoPaciente;
                    }
                    


                    List<PacienteFiltro> lista = new List<PacienteFiltro>();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        PacienteFiltro PF = new PacienteFiltro();
                        PF.IdPaciente = Convert.ToInt32(dr["IdPaciente"]);
                        
                        PF.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyyy-MM-dd");
                        PF.CURP = dr["CURP"].ToString();
                        PF.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                        PF.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                        PF.Nombres = dr["Nombres"].ToString();
                        PF.Edad = Convert.ToInt32(dr["Edad"]);
                        PF.Cama = dr["Cama"].ToString();
                        PF.Area = dr["Area"].ToString();
                        PF.S1 = dr["S1"].ToString();
                        PF.EstadoSalud = dr["EstadoSalud"].ToString();
                        PF.Diagnostico = dr["Diagnostico"].ToString();
                        PF.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyyy-MM-dd");
                        PF.Dias = Convert.ToInt32(dr["Dias"]);


                        lista.Add(PF);

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
                using (SqlCommand cmd = new SqlCommand("[dbo].[GenerarListaPacientesHospitalizados]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    
                    List<PacienteOficio> lista = new List<PacienteOficio>();
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PacienteOficio PO = new PacienteOficio();
                        PO.ID = Convert.ToInt32(dr["ID"]);
                        PO.FDN = Convert.ToDateTime(dr["FDN"]);
                        PO.CURP = dr["CURP"].ToString();
                        PO.ApellidoP = dr["ApellidoP"].ToString();
                        PO.ApellidoM = dr["ApellidoM"].ToString();
                        PO.Nombres = dr["Nombres"].ToString();
                        PO.Edad = Convert.ToInt32(dr["Edad"]);
                        PO.Cama = dr["Cama"].ToString();
                        PO.Area = dr["Area"].ToString();
                        PO.S1 = dr["S1"].ToString();
                        PO.EdoSalud = dr["EdoSalud"].ToString();
                        PO.Diagnostico = dr["Diagnostico"].ToString() ;
                        PO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
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

        public dynamic PdfListaPacientesInternados()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[GenerarListaPacientesInternados]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    List<PacienteOficio> lista = new List<PacienteOficio>();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PacienteOficio PO = new PacienteOficio();
                        PO.Cama = dr["Cama"].ToString();
                        PO.Area = dr["Area"].ToString();
                        PO.S1 = dr["S1"].ToString();
                        PO.ApellidoP = dr["ApellidoPaterno"].ToString();
                        PO.ApellidoM = dr["ApellidoMaterno"].ToString();
                        PO.Nombres = dr["Nombres"].ToString();
                        PO.Edad = Convert.ToInt32(dr["Edad"]);
                        PO.ID = Convert.ToInt32(dr["ID"]);
                        PO.Diagnostico = dr["Diagnostico"].ToString();
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



        public dynamic PdfListaIngresosAyer()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[GenerarListaIngresosAyer]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    List<PacienteOficio> lista = new List<PacienteOficio>();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PacienteOficio PO = new PacienteOficio();
                        PO.ID = Convert.ToInt32(dr["IdPaciente"]);
                        PO.ApellidoP = dr["ApellidoPaterno"].ToString();
                        PO.ApellidoM = dr["ApellidoMaterno"].ToString();
                        PO.Nombres = dr["Nombres"].ToString();
                        
                        PO.FDN = Convert.ToDateTime(dr["FechaNacimiento"]);
                        PO.CURP = dr["CURP"].ToString();
                        PO.S1 = dr["S1"].ToString();
                        PO.Cama = dr["Cama"].ToString();
                        PO.Area = dr["Area"].ToString();
                        PO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                        PO.EdoSalud = dr["EstadoSalud"].ToString();
                        PO.Diagnostico = dr["Diagnostico"].ToString();

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

        public dynamic PdfListaAreas()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[GenerarListaAreas]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    List<PacienteOficio> lista = new List<PacienteOficio>();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PacienteOficio PO = new PacienteOficio();
                        PO.Area = dr["Area"].ToString();
                        PO.Cama = dr["Cama"].ToString();
                        PO.S1 = dr["S1"].ToString();
                        PO.ApellidoP = dr["ApellidoPaterno"].ToString();
                        PO.ApellidoM = dr["ApellidoMaterno"].ToString();
                        PO.Nombres = dr["Nombres"].ToString();
                        PO.Edad = Convert.ToInt32(dr["Edad"]);
                        PO.FDN = Convert.ToDateTime(dr["FechaNacimiento"]);
                        PO.ID = Convert.ToInt32(dr["ID"]);
                        PO.Diagnostico = dr["Diagnostico"].ToString();
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


        public dynamic CambiarEstadoPaciente(int IdPaciente, string EstadoPaciente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[CambioEstadoPaciente]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;
                    cmd.Parameters.Add("@EstadoPaciente", System.Data.SqlDbType.NVarChar).Value = EstadoPaciente;


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

        public dynamic RegistrarDiagnostico(int IdPaciente ,string MedicoEncargado, string Diagnostico, string TipoDiagnostico, string Observaciones)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[RegistrarDiagnostico]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;
                    cmd.Parameters.Add("@NombreMedico", System.Data.SqlDbType.NVarChar).Value = MedicoEncargado;
                    cmd.Parameters.Add("@Diagnostico", System.Data.SqlDbType.NVarChar).Value = Diagnostico;
                    cmd.Parameters.Add("@TipoDiagnostico", System.Data.SqlDbType.NVarChar).Value = TipoDiagnostico;
                    cmd.Parameters.Add("@Observacion", System.Data.SqlDbType.NVarChar).Value = Observaciones;



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

        public dynamic RegistrarAlergia(int IdPaciente, string TipoAlergia, string Causante, string Detalles)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[RegistrarAlergia]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;
                    cmd.Parameters.Add("@TipoAlergia", System.Data.SqlDbType.NVarChar).Value = TipoAlergia;
                    cmd.Parameters.Add("@Causante", System.Data.SqlDbType.NVarChar).Value = Causante;
                    cmd.Parameters.Add("@Detalles", System.Data.SqlDbType.NVarChar).Value = Detalles;

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

        public dynamic RegistrarServicio(int IdPaciente, string Servicio)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[RegistrarServicio]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

                    cmd.Parameters.Add("@IdPaciente", System.Data.SqlDbType.Int).Value = IdPaciente;
                    cmd.Parameters.Add("@Servicio", System.Data.SqlDbType.NVarChar).Value = Servicio;

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


        public dynamic ModificarDetallesInformacionPaciente(int IdPaciente, DetallesPaciente d)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[ModificarDetallesInformacionPaciente]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    ApiRespuesta apiRespuesta = new ApiRespuesta();

                    cmd.Parameters.AddWithValue("@IdPaciente", IdPaciente);
                    cmd.Parameters.AddWithValue("@TipoAtencion", (object)d.TipoAtencion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoSalud", (object)d.EstadoSalud ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaIngreso", string.IsNullOrEmpty(d.FechaIngreso) ? (object)DBNull.Value : DateTime.Parse(d.FechaIngreso));
                    cmd.Parameters.AddWithValue("@Cama", (object)d.Cama ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Area", (object)d.Area ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TipoSeguro", (object)d.TipoSeguro ?? DBNull.Value);  // Afiliacion
                    cmd.Parameters.AddWithValue("@Folio", (object)d.Folio ?? DBNull.Value);            // NumeroAfiliacion
                    cmd.Parameters.AddWithValue("@EstadoPaciente", (object)d.EstadoPaciente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaAlta", string.IsNullOrEmpty(d.FechaAlta) ? (object)DBNull.Value : DateTime.Parse(d.FechaAlta));
                    cmd.Parameters.AddWithValue("@FechaEgreso", string.IsNullOrEmpty(d.FechaEgreso) ? (object)DBNull.Value : DateTime.Parse(d.FechaEgreso));
                    cmd.Parameters.AddWithValue("@MotivoEgreso", (object)d.MotivoEgreso ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SondaInstalada", (object)d.SondaInstalada ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaSondaInstalacion", string.IsNullOrEmpty(d.FechaSondaInstalacion) ? (object)DBNull.Value : DateTime.Parse(d.FechaSondaInstalacion));
                    cmd.Parameters.AddWithValue("@CirugiaProgramada", (object)d.CirugiaProgramada ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Procedimiento", (object)d.Procedimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaCirugia", string.IsNullOrEmpty(d.FechaCirugia) ? (object)DBNull.Value : DateTime.Parse(d.FechaCirugia));
                    cmd.Parameters.AddWithValue("@Observaciones", (object)d.ObservacionCirugia ?? DBNull.Value);

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

        public dynamic RecuperarEstadisticaSemanalHome()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[RecuperarEstadisticaSemanalHome]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<Estadistica> lista = new List<Estadistica>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Estadistica E = new Estadistica();
                        E.Fecha = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyyy-MM-dd");
                        E.PacientesIngresados = Convert.ToInt32(dr["PacientesIngresados"]);
                        lista.Add(E);
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

        public dynamic RecuperarEstadisticaDiariaHome()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[RecuperarEstadisticaDiariaHome]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    Estadistica E = new Estadistica();
                    while (dr.Read())
                    {
                        
                        E.PacientesIngresados = Convert.ToInt32(dr["PacientesIngresadosHoy"]);
                        E.PacientesEgresados = Convert.ToInt32(dr["PacientesEgresoHoy"]);
                    }
                    con.Close();
                    return E;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        public dynamic RecuperarPacientesHome()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[RecuperarPacientesHome]", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<DetallesPaciente> lista = new List<DetallesPaciente>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DetallesPaciente DE = new DetallesPaciente();
                        DE.NumeroExpediente = dr["IdPaciente"].ToString();
                        DE.Nombres = dr["Nombres"].ToString();
                        DE.CURP = dr["CURP"].ToString();
                        DE.EstadoPaciente = dr["EstadoPaciente"].ToString();
                        lista.Add(DE);
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