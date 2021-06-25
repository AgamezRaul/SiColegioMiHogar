using BackEnd.Base;
using System;
using System.Collections.Generic;

namespace BackEnd.Boletin.Dominio
{
    public class Boletin : Entity<int>
    {

        public DateTime FechaGeneracion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdPeriodo { get; set; }
        public Boletin(int idEstudiante, int idPeriodo, DateTime fechaGeneracion)
        {
            FechaGeneracion = fechaGeneracion;
            IdEstudiante = idEstudiante;
            IdPeriodo = idPeriodo;
        }

        public IReadOnlyList<string> CanCrear(Boletin boletin)
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
