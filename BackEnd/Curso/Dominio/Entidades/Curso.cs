using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Curso.Dominio
{
    public class Curso : Entity<int>
    {
        public string Nombre { get; set; }        
        public int MaxEstudiantes { get; set; }
        public int IdDirectorDocente { get; set; }
        public string Letra { get; set; }

        public Curso(string nombre, int maxEstudiantes, int idDirectorDocente, string letra)
        {
            Nombre = nombre;
            MaxEstudiantes = maxEstudiantes;
            IdDirectorDocente = idDirectorDocente;
            Letra = letra;
        }

        public IReadOnlyList<string> CanCrear(Curso curso)
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
