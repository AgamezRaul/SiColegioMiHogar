using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Estudiante.Dominio;

namespace BackEnd.Nota.Dominio.Entidades
{
    public class Nota : Entity<int>
    {
        public string Descripcion { get; set; }
        public double NotaAlumno { get; set; }
        public DateTime FechaNota { get; set; }
        public int IdEstudiante { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }
        

        public Nota(string Descripcion, DateTime fechaNota, double NotaAlumno, int IdEstudiante, int IdMateria, int IdPeriodo)
        {
            this.Descripcion = Descripcion;
            this.FechaNota = fechaNota;
            this.IdEstudiante = IdEstudiante;
            this.IdMateria = IdMateria;
            this.NotaAlumno = NotaAlumno;
            this.IdPeriodo = IdPeriodo;
        }

        public IReadOnlyList<string> CanCrear(Nota nota)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(nota.Descripcion))
                errors.Add("Campo Descripcion  vacio");
            if (nota.IdEstudiante == 0)
                errors.Add("Campo IdEstudiante  vacio");
            if (string.IsNullOrEmpty(nota.FechaNota.ToString()))
                errors.Add("Campo Fecha de Pago vacio");
            if (nota.IdMateria == 0)
                errors.Add("Campo  IdMateria vacio");
            if (nota.IdPeriodo == 0)
                errors.Add("Campo IdPeriodo vacio");
            if (nota.NotaAlumno == 0)
                errors.Add("Campo Nota del Alumno vacio");
            return errors;
        }
    }
}
