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

namespace SAG.View.Pacientes
{
    public partial class OficiosPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static dynamic GetTest()
        {
            return new { Message = "Hello World" };
        }


        [WebMethod]
        public static dynamic GetOficioListaPacientesHopitalizados()
        {
            var pacientes = new List<PacienteOficio>
            {
            new PacienteOficio { ID = 1, NoExp = "123", FDN = new DateTime(1990, 1, 1), CURP = "CURP1", ApellidoP = "Perez", ApellidoM = "Garcia", Nombres = "Juan", Edad = 34, Cama = "A1", Area = "General", Servicio1 = "Medicina Interna", Servicio2 = "Cardiología", EdoSalud = "Estable", Diagnostico = "Gripe", FechaIngreso = new DateTime(2023, 2, 1), DiasInternado = 10 },
            new PacienteOficio { ID = 2, NoExp = "456", FDN = new DateTime(1985, 6, 15), CURP = "CURP2", ApellidoP = "Lopez", ApellidoM = "Martinez", Nombres = "Maria", Edad = 38, Cama = "B2", Area = "Pediatría", Servicio1 = "Pediatría", Servicio2 = "Dermatología", EdoSalud = "Grave", Diagnostico = "Bronquitis", FechaIngreso = new DateTime(2023, 1, 25), DiasInternado = 15 }
            // Agrega más pacientes según sea necesario
            };

            ControllerPaciente controllerPaciente = new ControllerPaciente();
            List<PacienteOficio> lista = new List<PacienteOficio>();
            try
            {
                //lista = controllerPaciente.
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f); // 36 puntos = 1.27 cm
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();

                // Título del reporte
                Paragraph title = new Paragraph("Lista de Pacientes Hospitalizados", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
                title.Alignment = Element.ALIGN_LEFT;
                doc.Add(title);

                // Fecha de generación del reporte
                Paragraph date = new Paragraph(DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt"), new Font(Font.FontFamily.HELVETICA, 10, Font.ITALIC));
                date.Alignment = Element.ALIGN_RIGHT;
                doc.Add(date);

                // Espacio entre el título/fecha y la tabla
                doc.Add(new Paragraph(" "));

                // Crear la tabla con las columnas especificadas
                PdfPTable table = new PdfPTable(16); // 16 columnas
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 3f, 2f, 2f, 2f, 2f, 2f, 2f, 3f, 2f, 2f });

                // Agregar encabezados a la tabla
                AddTableHeader(table, "ID");
                AddTableHeader(table, "No Exp");
                AddTableHeader(table, "FDN");
                AddTableHeader(table, "CURP");
                AddTableHeader(table, "ApellidoP");
                AddTableHeader(table, "ApellidoM");
                AddTableHeader(table, "Nombres");
                AddTableHeader(table, "Edad");
                AddTableHeader(table, "Cama");
                AddTableHeader(table, "Area");
                AddTableHeader(table, "Servicio 1");
                AddTableHeader(table, "Servicio 2");
                AddTableHeader(table, "EdoSalud");
                AddTableHeader(table, "Diagnostico");
                AddTableHeader(table, "FechaIngreso");
                AddTableHeader(table, "Dias Internado");

                // Agregar datos de los pacientes a la tabla
                foreach (var paciente in pacientes)
                {
                    table.AddCell(paciente.ID.ToString());
                    table.AddCell(paciente.NoExp);
                    table.AddCell(paciente.FDN.ToString("dd/MM/yyyy"));
                    table.AddCell(paciente.CURP);
                    table.AddCell(paciente.ApellidoP);
                    table.AddCell(paciente.ApellidoM);
                    table.AddCell(paciente.Nombres);
                    table.AddCell(paciente.Edad.ToString());
                    table.AddCell(paciente.Cama);
                    table.AddCell(paciente.Area);
                    table.AddCell(paciente.Servicio1);
                    table.AddCell(paciente.Servicio2);
                    table.AddCell(paciente.EdoSalud);
                    table.AddCell(paciente.Diagnostico);
                    table.AddCell(paciente.FechaIngreso.ToString("dd/MM/yyyy"));
                    table.AddCell(paciente.DiasInternado.ToString());
                }

                doc.Add(table);
                doc.Close();

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                List<PdfRespuesta> pdfRespuesta = new List<PdfRespuesta>();
                pdfRespuesta.Add(new PdfRespuesta { Name = "ListaPacientesHospitalizados.pdf", Data = base64String });
                //pdfRespuesta.Add(new PdfRespuesta { Name = "ListaPacientesHospitalizados.pdf", Data = "test" });
                //return new { FileContent = base64String, FileName = "ListaPacientesHospitalizados.pdf" };
                return pdfRespuesta;
            }


        }

        private static void AddTableHeader(PdfPTable table, string header)
        {
            PdfPCell cell = new PdfPCell(new Phrase(header));
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
        public string Servicio1 { get; set; }
        public string Servicio2 { get; set; }
        public string EdoSalud { get; set; }
        public string Diagnostico { get; set; }
        public dynamic FechaIngreso { get; set; }
        public int DiasInternado { get; set; }
    }
}