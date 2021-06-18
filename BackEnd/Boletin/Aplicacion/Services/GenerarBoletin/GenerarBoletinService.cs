using BackEnd.Boletin.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Linq;
using System.Threading.Tasks;
using Document = iTextSharp.text.Document;
using Rectangle = iTextSharp.text.Rectangle;
using BackEnd.Base;
using System.Runtime.InteropServices;

namespace BackEnd.Boletin.Aplicacion.Services.GenerarBoletin
{
    public class GenerarBoletinService
    {
        readonly IUnitOfWork _unitOfWork;
        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);
        public GenerarBoletinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        string ruta = GetDownloadsPath()+ @"\BoletinPDF.pdf";
        CrearBoletinRequest Boletin;
        public void GuardarPdfBoletin(CrearBoletinRequest boletin)
        {
            Boletin = boletin;
            FileStream fs = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL, 40, 40, 40, 40);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);
            document.AddTitle("Boletin del colegio Mi Hogar");
            document.AddCreator("SI");

            document.Open();
            DateTime fecha = DateTime.Now;
            string fechaactual = fecha.ToString();
            // Escribimos el encabezamiento en el documento
            document.Add(new Paragraph(fechaactual));
            document.Add(Chunk.NEWLINE);
            //margenes
            var content = pw.DirectContent;
            var pageBorderRect = new Rectangle(document.PageSize);

            pageBorderRect.Left += document.LeftMargin;
            pageBorderRect.Right -= document.RightMargin;
            pageBorderRect.Top -= document.TopMargin;
            pageBorderRect.Bottom += document.BottomMargin;

            content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
            content.Stroke();
            //pie de pagina 

            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 50F;
            cell = new PdfPCell(new Phrase("Colegio_Mi_Hogar", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 500, document.Bottom, pw.DirectContent);




            document.Add(new Paragraph("                                Boletion SI Col Mi Hogar", FontFactory.GetFont("ARIAL BLACK", 20, iTextSharp.text.Font.BOLD)));

            // logo
           /* string rutaimagen = @"logo.png";
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaimagen);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            document.Add(imagen);*/
            //lo que dimos en clase 

            document.Add(new Paragraph($"       Periodo: {boletin.IdPeriodo}  \t Fecha de generacion: {boletin.FechaGeneracion}"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("      ---------------------------------------------------------------------------------------------------------------"));
            document.Close();
        }
        public string BoletinPDF(CrearBoletinRequest request)
        {
            string resultado = string.Empty;
            try
            {
                GuardarPdfBoletin(request);
                resultado = "Boletin Generado";
            }
            catch (Exception er)
            {
                resultado = "Error al generar el boletin: " + er.Message;
            }
            Console.WriteLine(resultado);
            return resultado;
        }
        public static string GetDownloadsPath()
        {
            if (Environment.OSVersion.Version.Major < 6) throw new NotSupportedException();

            IntPtr pathPtr = IntPtr.Zero;

            try
            {
                SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
                return Marshal.PtrToStringUni(pathPtr);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pathPtr);
            }
        }
    }
}

