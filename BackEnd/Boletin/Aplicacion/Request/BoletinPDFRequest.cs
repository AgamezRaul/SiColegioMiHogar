using System.Collections.Generic;

namespace BackEnd.Boletin.Aplicacion.Request
{
    public class BoletinPDFRequest
    {
        public string IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public string CursoEstudiante { get; set; }
        public string Jornada { get; set; }
        public int Periodo { get; set; }
        public int Puesto { get; set; }
        public int Anio { get; set; }
        public string Observaciones { get; set; }
        public string DocenteCurso { get; set; }
        List<ListaMaterias> listaMaterias { get; set; }
    }

    public class ListaMaterias
    {
        public string NombreMateria { get; set; }
        public int Fallas { get; set; }
        public double NotaPeriodoUno { get; set; }
        public double NotaPeriodoDos { get; set; }
        public double NotaPeriodoTres { get; set; }
        public double NotaPeriodoCuarto { get; set; }
        public double NotaPromedio { get; set; }
        public string Desempenio { get; set; }
    }
}
