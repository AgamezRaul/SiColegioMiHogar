using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Base;

namespace BackEnd.materias.Dominio.Entidades
{
    public class Materias : Entity<int>
    {
        public int idMateria { get; set; }
        public string NombreMateria { get; set; }
        public int IdDocente { get; set; }
        public int IdCurso { get; set; }

        public Materias() { }

        public Materias(int ideMateria, string nombreMateria, int ideDocente, int ideCurso) {
            idMateria = ideMateria;
            NombreMateria = nombreMateria;
            IdDocente = ideCurso;
            IdCurso = ideCurso;
        }

        public IReadOnlyList<string> CanCrear(Materias materias)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(materias.idMateria.ToString()))
                errors.Add("Campo codigo de materia vacio");
            if (string.IsNullOrEmpty(materias.NombreMateria))
                errors.Add("Campo nombre de la materia vacio");
            if (string.IsNullOrEmpty(materias.IdDocente.ToString()))
                errors.Add("Campo codigo del docente vacio");
            if (string.IsNullOrEmpty(materias.IdCurso.ToString()))
                errors.Add("Campo codigo del curso vacio");
            return errors;
        }
    }
}
