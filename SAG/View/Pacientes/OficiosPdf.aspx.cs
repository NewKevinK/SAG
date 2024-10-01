using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.Services;
using SAG.Models;
using SAG.Controller;
using System.Collections;
using System.Web.Script.Serialization;
using System.Security.Claims;

namespace SAG.View.Pacientes
{
    public partial class OficiosPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Eliminar todas las sesiones
            Session.Clear();
            Session.Abandon();

            // Desactivar la caché
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetNoStore();

            // Verificar si el usuario está autenticado
            var token = HttpContext.Current.Request.Cookies["JWTToken"]?.Value;

            if (string.IsNullOrEmpty(token) || ValidateToken(token) == null)
            {
                // Si el token no es válido o no está presente, redirigir al inicio de sesión
                Response.Redirect("~/View/Inicio/Login.aspx");
            }
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var principal = JWT.GetPrincipal(token);

                if (principal == null)
                {
                    return false;
                }

                var identity = principal.Identity as ClaimsIdentity;

                if (identity == null)
                {
                    return false;
                }

                var usernameClaim = identity.FindFirst(ClaimTypes.Name);

                if (usernameClaim == null)
                {
                    return false;
                }

                var username = usernameClaim.Value;

                // Opcional: realizar más validaciones si es necesario
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public static dynamic GetListaAreas()
        {
            if (HttpContext.Current.Request.Cookies["JWTToken"] == null)
            {
                return "No se ha iniciado sesión";
            }
            

            var pacientes = new List<PacienteOficio>
            {
                new PacienteOficio { ID = 1, NoExp = "123", FDN = new DateTime(1990, 1, 1), CURP = "CURP1", ApellidoP = "Perez", ApellidoM = "Garcia", Nombres = "Juan", Edad = 34, Cama = "A1", Area = "General", S1 = "Medicina Interna", EdoSalud = "Estable", Diagnostico = "Gripe", FechaIngreso = new DateTime(2023, 2, 1), DiasInternado = 10 },
                new PacienteOficio { ID = 2, NoExp = "456", FDN = new DateTime(1985, 6, 15), CURP = "CURP2", ApellidoP = "Lopez", ApellidoM = "Martinez", Nombres = "Maria", Edad = 38, Cama = "B2", Area = "Pediatría", S1 = "Pediatría", EdoSalud = "Grave", Diagnostico = "Bronquitis", FechaIngreso = new DateTime(2023, 1, 25), DiasInternado = 15 }
                // Agrega más pacientes según sea necesario
            };

            var pacientesPorArea = new Dictionary<string, List<PacienteOficio>>();
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                pacientes = controllerPaciente.PdfListaAreas();

                // Agrupar pacientes por área
                pacientesPorArea = pacientes.GroupBy(p => p.Area)
                                             .ToDictionary(g => g.Key, g => g.ToList());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configurar el documento con márgenes de 0.7 cm
                Document doc = new Document(PageSize.A4, 20f, 20f, 36f, 36f); // 20 puntos ≈ 0.7 cm
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();

                // Título del reporte
                Font titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                Paragraph title = new Paragraph("Lista de Pacientes por Área", titleFont);
                title.Alignment = Element.ALIGN_LEFT;
                doc.Add(title);

                // Fecha de generación del reporte
                Font dateFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                Paragraph date = new Paragraph(DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt"), dateFont);
                date.Alignment = Element.ALIGN_RIGHT;
                doc.Add(date);

                // Espacio entre el título/fecha y la tabla
                doc.Add(new Paragraph(" "));

                // Crear la tabla con las columnas especificadas
                foreach (var area in pacientesPorArea.Keys)
                {
                    // Añadir nombre del área
                    Paragraph areaTitle = new Paragraph(area, FontFactory.GetFont("Arial", 12, Font.BOLD));
                    areaTitle.Alignment = Element.ALIGN_LEFT;
                    doc.Add(areaTitle);

                    // Espacio entre el área y la tabla
                    doc.Add(new Paragraph(" "));

                    PdfPTable table = new PdfPTable(10); // 10 columnas
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 1f, 2f, 2f, 2f, 1f, 1f, 1f, 4f, 1f });

                    // Fuentes para los encabezados y valores
                    Font headerFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
                    Font valueFont = FontFactory.GetFont("Arial", 7);

                    // Agregar encabezados a la tabla
                    AddTableHeader(table, "Cama", headerFont);
                    AddTableHeader(table, "S1", headerFont);
                    AddTableHeader(table, "Apellido Paterno", headerFont);
                    AddTableHeader(table, "Apellido Materno", headerFont);
                    AddTableHeader(table, "Nombres", headerFont);
                    AddTableHeader(table, "Edad", headerFont);
                    AddTableHeader(table, "FDN", headerFont);
                    AddTableHeader(table, "ID", headerFont);
                    AddTableHeader(table, "Diagnostico", headerFont);
                    AddTableHeader(table, "Dias Internado", headerFont);

                    // Agregar datos de los pacientes a la tabla
                    foreach (var paciente in pacientesPorArea[area])
                    {
                        table.AddCell(new PdfPCell(new Phrase(paciente.Cama, valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.S1, valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoP, valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoM, valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.Nombres, valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.Edad.ToString(), valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.FDN.ToString("dd/MM/yyyy"), valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.ID.ToString(), valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.Diagnostico, valueFont)));
                        table.AddCell(new PdfPCell(new Phrase(paciente.DiasInternado.ToString(), valueFont)));
                    }

                    doc.Add(table);

                    // Espacio entre las áreas
                    doc.Add(new Paragraph(" "));
                }

                doc.Close();

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                List<PdfRespuesta> pdfRespuesta = new List<PdfRespuesta>();
                pdfRespuesta.Add(new PdfRespuesta { Name = "ListaAreas.pdf", Data = base64String });
                return pdfRespuesta;
            }
        }

        [WebMethod]
        public static dynamic GetListaIngresosAyer()
        {
            var pacientes = new List<PacienteOficio>
            {
                new PacienteOficio { ID = 1, NoExp = "123", FDN = new DateTime(1990, 1, 1), CURP = "CURP1", ApellidoP = "Perez", ApellidoM = "Garcia", Nombres = "Juan", Cama = "A1", Area = "General", S1 = "Medicina Interna", EdoSalud = "Estable", Diagnostico = "Gripe", FechaIngreso = DateTime.Now.AddDays(-1) },
                new PacienteOficio { ID = 2, NoExp = "456", FDN = new DateTime(1985, 6, 15), CURP = "CURP2", ApellidoP = "Lopez", ApellidoM = "Martinez", Nombres = "Maria", Cama = "B2", Area = "Pediatría", S1 = "Pediatría", EdoSalud = "Grave", Diagnostico = "Bronquitis", FechaIngreso = DateTime.Now.AddDays(-1) }
                // Agrega más pacientes según sea necesario
            };

            var pacientesAyer = new List<PacienteOficio>();
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                pacientesAyer = controllerPaciente.PdfListaIngresosAyer();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configurar el documento con márgenes de 0.7 cm
                Document doc = new Document(PageSize.A4.Rotate(), 20f, 20f, 36f, 36f); // 20 puntos ≈ 0.7 cm
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();

                // Título del reporte
                Font titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                Paragraph title = new Paragraph("Lista de Ingresos de Ayer", titleFont);
                title.Alignment = Element.ALIGN_LEFT;
                doc.Add(title);

                // Fecha de generación del reporte
                Font dateFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                Paragraph date = new Paragraph(DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt"), dateFont);
                date.Alignment = Element.ALIGN_RIGHT;
                doc.Add(date);

                // Espacio entre el título/fecha y la tabla
                doc.Add(new Paragraph(" "));

                // Crear la tabla con las columnas especificadas
                PdfPTable table = new PdfPTable(12); // 13 columnas
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1f, 2f, 2f, 2f,  2f, 2f, 1f, 1f, 1f, 2f, 2f, 4f });


                // Fuentes para los encabezados y valores
                Font headerFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
                Font valueFont = FontFactory.GetFont("Arial", 7);

                // Agregar encabezados a la tabla
                AddTableHeader(table, "ID", headerFont);
                AddTableHeader(table, "Apellido Paterno", headerFont);
                AddTableHeader(table, "Apellido Materno", headerFont);
                AddTableHeader(table, "Nombres", headerFont);
                //AddTableHeader(table, "No Exp", headerFont);
                AddTableHeader(table, "FDN", headerFont);
                AddTableHeader(table, "CURP", headerFont);
                AddTableHeader(table, "S1", headerFont);
                AddTableHeader(table, "Cama", headerFont);
                AddTableHeader(table, "Area", headerFont);
                AddTableHeader(table, "Fecha Ingreso", headerFont);
                AddTableHeader(table, "EdoSalud", headerFont);
                AddTableHeader(table, "Diagnostico", headerFont);

                // Agregar datos de los pacientes a la tabla
                foreach (var paciente in pacientesAyer)
                {
                    table.AddCell(new PdfPCell(new Phrase(paciente.ID.ToString(), valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoP, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoM, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Nombres, valueFont)));
                    //table.AddCell(new PdfPCell(new Phrase(paciente.NoExp, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.FDN.ToString("dd/MM/yyyy"), valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.CURP, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.S1, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Cama, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Area, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.FechaIngreso.ToString("dd/MM/yyyy"), valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.EdoSalud, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Diagnostico, valueFont)));
                }

                doc.Add(table);
                doc.Close();

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                List<PdfRespuesta> pdfRespuesta = new List<PdfRespuesta>();
                pdfRespuesta.Add(new PdfRespuesta { Name = "ListaIngresosAyer.pdf", Data = base64String });
                return pdfRespuesta;
            }
        }

        [WebMethod]
        public static dynamic GetOficioListaPacientesInternados()
        {
            var pacientes = new List<PacienteOficio>
            {
                new PacienteOficio { Cama = "A1", Area = "General", S1 = "Medicina Interna", ApellidoP = "Perez", ApellidoM = "Garcia", Nombres = "Juan", Edad = 34, ID = 123, Diagnostico = "Gripe", DiasInternado = 10 },
                new PacienteOficio { Cama = "B2", Area = "Pediatría", S1 = "Pediatría", ApellidoP = "Lopez", ApellidoM = "Martinez", Nombres = "Maria", Edad = 38, ID = 456, Diagnostico = "Bronquitis", DiasInternado = 15 }
                // Agrega más pacientes según sea necesario
            };

            var pacientes2 = new List<PacienteOficio>();
            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                pacientes2 = controllerPaciente.PdfListaPacientesInternados();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configurar el documento con márgenes de 0.7 cm
                Document doc = new Document(PageSize.A4, 20f, 20f, 36f, 36f); // 20 puntos ≈ 0.7 cm
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();

                // Título del reporte
                Font titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                Paragraph title = new Paragraph("Lista de Pacientes Internados", titleFont);
                title.Alignment = Element.ALIGN_LEFT;
                doc.Add(title);

                // Fecha de generación del reporte
                Font dateFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                Paragraph date = new Paragraph(DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt"), dateFont);
                date.Alignment = Element.ALIGN_RIGHT;
                doc.Add(date);

                // Espacio entre el título/fecha y la tabla
                doc.Add(new Paragraph(" "));

                // Crear la tabla con las columnas especificadas
                PdfPTable table = new PdfPTable(10); // 10 columnas
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1f, 1f, 1f, 2f, 2f, 2f, 1f, 1f, 3f, 1f });

                // Fuentes para los encabezados y valores
                Font headerFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
                Font valueFont = FontFactory.GetFont("Arial", 7);

                // Agregar encabezados a la tabla
                AddTableHeader(table, "Cama", headerFont);
                AddTableHeader(table, "Area", headerFont);
                AddTableHeader(table, "S1", headerFont);
                AddTableHeader(table, "Apellido Paterno", headerFont);
                AddTableHeader(table, "Apellido Materno", headerFont);
                AddTableHeader(table, "Nombres", headerFont);
                AddTableHeader(table, "Edad", headerFont);
                AddTableHeader(table, "ID", headerFont);
                AddTableHeader(table, "Diagnostico", headerFont);
                AddTableHeader(table, "Dias Internado", headerFont);

                // Agregar datos de los pacientes a la tabla
                foreach (var paciente in pacientes2)
                {
                    table.AddCell(new PdfPCell(new Phrase(paciente.Cama, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Area, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.S1, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoP, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoM, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Nombres, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Edad.ToString(), valueFont)));
                    //table.AddCell(new PdfPCell(new Phrase(paciente.NoExp, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.ID.ToString(), valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Diagnostico, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.DiasInternado.ToString(), valueFont)));
                }

                doc.Add(table);
                doc.Close();

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                List<PdfRespuesta> pdfRespuesta = new List<PdfRespuesta>();
                pdfRespuesta.Add(new PdfRespuesta { Name = "ListaPacientesInternados.pdf", Data = base64String });
                return pdfRespuesta;
            }
        }


        [WebMethod]
        public static dynamic GetOficioListaPacientesHopitalizados()
        {
            var pacientes = new List<PacienteOficio>
            {
            new PacienteOficio { ID = 1, NoExp = "123", FDN = new DateTime(1990, 1, 1), CURP = "CURP1", ApellidoP = "Perez", ApellidoM = "Garcia", Nombres = "Juan", Edad = 34, Cama = "A1", Area = "General", S1 = "Medicina Interna", EdoSalud = "Estable", Diagnostico = "Gripe", FechaIngreso = new DateTime(2023, 2, 1), DiasInternado = 10 },
            new PacienteOficio { ID = 2, NoExp = "456", FDN = new DateTime(1985, 6, 15), CURP = "CURP2", ApellidoP = "Lopez", ApellidoM = "Martinez", Nombres = "Maria", Edad = 38, Cama = "B2", Area = "Pediatría", S1 = "Pediatría", EdoSalud = "Grave", Diagnostico = "Bronquitis", FechaIngreso = new DateTime(2023, 1, 25), DiasInternado = 15 }
            // Agrega más pacientes según sea necesario
            };

            var pacientes2 = new List<PacienteOficio>{ };



            try
            {
                ControllerPaciente controllerPaciente = new ControllerPaciente();
                pacientes2 = controllerPaciente.PdfListaPacientesHopitalizados();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configurar el documento con márgenes de 0.7 cm
                Document doc = new Document(PageSize.A4.Rotate(), 20f, 20f, 36f, 36f); // 20 puntos ≈ 0.7 cm
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();

                // Título del reporte
                Font titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                Paragraph title = new Paragraph("Lista de Pacientes Hospitalizados", titleFont);
                title.Alignment = Element.ALIGN_LEFT;
                doc.Add(title);

                // Fecha de generación del reporte
                Font dateFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                Paragraph date = new Paragraph(DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt"), dateFont);
                date.Alignment = Element.ALIGN_RIGHT;
                doc.Add(date);

                // Espacio entre el título/fecha y la tabla
                doc.Add(new Paragraph(" "));

                // Crear la tabla con las columnas especificadas
                PdfPTable table = new PdfPTable(14); // 16 columnas
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1f,  2f, 2f, 2f, 2f, 2f, 1f, 1f, 2f, 2f, 2f, 6f, 2f, 2f });

                // Fuentes para los encabezados y valores
                Font headerFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
                Font idFont = FontFactory.GetFont("Arial", 5);
                Font valueFont = FontFactory.GetFont("Arial", 7);

                // Agregar encabezados a la tabla
                AddTableHeader(table, "ID", headerFont);
                AddTableHeader(table, "FDN", headerFont);
                AddTableHeader(table, "CURP", headerFont);
                AddTableHeader(table, "Apellido P", headerFont);
                AddTableHeader(table, "ApellidoM", headerFont);
                AddTableHeader(table, "Nombres", headerFont);
                AddTableHeader(table, "Edad", headerFont);
                AddTableHeader(table, "Cama", headerFont);
                AddTableHeader(table, "Area", headerFont);
                AddTableHeader(table, "S1", headerFont);
                AddTableHeader(table, "EdoSalud", headerFont);
                AddTableHeader(table, "Diagnostico", headerFont);
                AddTableHeader(table, "Fecha Ingreso", headerFont);
                AddTableHeader(table, "Dias Internado", headerFont);

                // Agregar datos de los pacientes a la tabla
                foreach (var paciente in pacientes2)
                {
                    table.AddCell(new PdfPCell(new Phrase(paciente.ID.ToString(), idFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.FDN.ToString("dd/MM/yyyy"), valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.CURP, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoP, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.ApellidoM, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Nombres, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Edad.ToString(), valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Cama, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Area, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.S1, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.EdoSalud, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.Diagnostico, valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.FechaIngreso.ToString("dd/MM/yyyy"), valueFont)));
                    table.AddCell(new PdfPCell(new Phrase(paciente.DiasInternado.ToString(), valueFont)));
                }

                doc.Add(table);
                doc.Close();

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                List<PdfRespuesta> pdfRespuesta = new List<PdfRespuesta>();
                pdfRespuesta.Add(new PdfRespuesta { Name = "ListaPacientesHospitalizados.pdf", Data = base64String });
                return pdfRespuesta;
            }


        }

        private static void AddTableHeader(PdfPTable table, string header, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(header, font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
        }



    }





    public class PacienteOficio
    {
        public int ID { get; set; }
        public string NoExp { get; set; }
        public dynamic FDN { get; set; }
        public string CURP { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Cama { get; set; }
        public string Area { get; set; }
        public string S1 { get; set; }
        public string EdoSalud { get; set; }
        public string Diagnostico { get; set; }
        public dynamic FechaIngreso { get; set; }
        public int DiasInternado { get; set; }
        
    }
}