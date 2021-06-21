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
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Nota.Aplicacion.Request;
using BackEnd.Periodo.Aplicacion.Request;
using BackEnd.Materia.Aplicacion.Request;
using BackEnd.Curso.Aplicacion.Request;

namespace BackEnd.Boletin.Aplicacion.Services.GenerarBoletin
{
    public class GenerarBoletinService
    {
        /*readonly IUnitOfWork _unitOfWork;
        readonly MiHogarContext _context;
        readonly BoletinPDFRequest _boletinPDFRequest;
        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);
        public GenerarBoletinService(MiHogarContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _boletinPDFRequest = new BoletinPDFRequest();
        }
        string ruta = GetDownloadsPath()+ @"\BoletinPDF.pdf";
        CrearBoletinRequest Boletin;
        public void GuardarPdfBoletin(BoletinPDFRequest boletinPDFRequest)
        {
           
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

           /* document.Add(new Paragraph($"      Nombre del Periodo: {periodo.NombrePeriodo} \t  #: {periodo.NumeroPeriodo} \t Fecha de generacion: {boletin.FechaGeneracion}"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph($"      Curso: {curso.nombre} - {curso.Letra} \t  Estudiante: {estudiante.NomEstudiante} \t Identificacion: {estudiante.IdeEstudiante} \t Puesto: {puestos(curso)}" ));*/
           /*---- document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("      ---------------------------------------------------------------------------------------------------------------"));
            document.Close();
        }
        public string puestos(CrearCursoRequest curso) {
            //mirar como ordenar los puestos de cada integrante
            return "3";
        }
        
        public BoletinPDFRequest BoletinPDF(int idEstudiante, int idPeriodo)
        {
            var materias = (from e in _context.Set<BackEnd.Estudiante.Dominio.Estudiante>()
                            join ec in _context.Set<BackEnd.EstudianteCurso.Dominio.EstudianteCurso>()
                            on e.Id equals ec.IdEstudiante
                            join c in _context.Set<BackEnd.Curso.Dominio.Curso>()
                            on ec.IdCurso equals c.Id
                            join m in _context.Set<BackEnd.Materia.Dominio.Entidades.Materias>()
                            on c.Id equals m.IdCurso
                            where e.Id == idEstudiante
                            select new
                            {
                                Id = m.Id,
                                NombreMateria = m.NombreMateria,
                            }).ToList();
            foreach (var materia in materias)
            {
                
            }


            var notaPeriodos = (from m in materias
                                join np in _context.Set<BackEnd.NotaPeriodo.Dominio.NotaPeriodo>()
                                on m.Id equals np.IdMateria
                                select new
                                {
                                    Id = m.Id,
                                    NombreMateria = m.NombreMateria,
                                    Periodo = np.IdPeriodo,
                                    NotaPeriodo = np.Nota
                                }).ToList();


            var estudiante = (from e in _context.Set<BackEnd.Estudiante.Dominio.Estudiante>()
                              join ec in _context.Set<BackEnd.EstudianteCurso.Dominio.EstudianteCurso>()
                              on e.Id equals ec.IdEstudiante
                              join c in _context.Set<BackEnd.Curso.Dominio.Curso>()
                              on ec.IdCurso equals c.Id
                              join d in _context.Set<BackEnd.Docente.Dominio.Docente>()
                              on c.IdDirectorDocente equals d.Id
                              where e.Id == idEstudiante
                              select new
                              {
                                  IdEstudiante = e.IdeEstudiante,
                                  NombreEstudiante = e.NomEstudiante,
                                  CursoEstudiante = c.Nombre + " " + c.Letra,
                                  DocenteCurso = d.NombreCompleto,

                              }).ToList();
            
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
        }*/
        
    }
}

