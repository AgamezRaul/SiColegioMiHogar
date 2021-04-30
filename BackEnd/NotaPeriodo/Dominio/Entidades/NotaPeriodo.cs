using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.NotaPeriodo.Dominio
{
    public class NotaPeriodo : Entity<int>
    {
        public double Nota { get; set; }
        public string Observacion { get; set; }
        public int IdPeriodo { get; set; }
        public int IdMateria { get; set; }
        public NotaPeriodo(double nota, string observacion, int idPeriodo, int idMateria)
        {
            Nota = nota;
            Observacion = observacion;
            IdPeriodo = idPeriodo;
            IdMateria = idMateria;
        }
        public IReadOnlyList<string> CanCrear(NotaPeriodo notaPeriodo)
        {
            var errors = new List<string>();
            /*
            if (string.IsNullOrEmpty(curso.Nombre))
                errors.Add("El campo nombre está vacío");
            if (curso.MaxEstudiantes == 0)
                errors.Add("El campo Maximos estudiantes debe ser mayor que cero");
            if (curso.IdDirectorDocente == 0)
                errors.Add("El id debe ser mayor que cero");*/
            return errors;
        }

    }
}
