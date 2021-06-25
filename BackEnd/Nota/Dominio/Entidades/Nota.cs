using BackEnd.Base;
using System;
using System.Collections.Generic;

namespace BackEnd.Nota.Dominio.Entidades
{
    public class Nota : Entity<int>
    {
        public double NotaAlumno { get; set; }
        public DateTime FechaNota { get; set; }
        public int IdActividad { get; set; }
        public int IdEstudiante { get; set; }

        public Nota(double notaAlumno, DateTime fechaNota, int idActividad, int idEstudiante)
        {
            NotaAlumno = notaAlumno;
            FechaNota = fechaNota;
            IdActividad = idActividad;
            IdEstudiante = idEstudiante;
        }

        public IReadOnlyList<string> CanCrear(Nota nota)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(nota.FechaNota.ToString()))
                errors.Add("Campo Fecha Nota vacio");
            if (nota.NotaAlumno == 0)
                errors.Add("Campo Nota alumno vacio");
            if (nota.IdActividad == 0)
                errors.Add("Campo Id Actividad vacio");
            if (nota.IdEstudiante == 0)
                errors.Add("Campo Id Actividad vacio");
            return errors;
        }
    }
}
