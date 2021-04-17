using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Base;

namespace BackEnd.Materia.Dominio.Entidades
{
    public class Materias : Entity<int>
    {
        public string NombreMateria { get; set; }
        public int IdDocente { get; set; }
        public int IdCurso { get; set; }

        public Materias() { }

        public Materias(string nombreMateria, int ideDocente, int ideCurso)
        {
            NombreMateria = nombreMateria;
            IdDocente = ideDocente;
            IdCurso = ideCurso;
        }

        public IReadOnlyList<string> CanCrear(Materias materias)
        {
            
            var errors = new List<string>();/*
            if (materias.IdDocente == 0)
                errors.Add("Campo codigo del docente vacio");
            if (materias.IdCurso == 0)
                errors.Add("Campo codigo del curso vacio");
            if (string.IsNullOrEmpty(materias.NombreMateria) )
                errors.Add("Campo nombre de la materia vacio");*/
            return errors;
        }
    }
}
