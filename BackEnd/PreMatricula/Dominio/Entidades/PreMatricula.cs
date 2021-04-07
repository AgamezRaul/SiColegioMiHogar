using BackEnd.Base;
using System;
using System.Collections.Generic;

namespace BackEnd.PreMatricula.Dominio
{
    public class PreMatricula : Entity<int>
    {
       

        public DateTime FecPrematricula { get; set; }
        public int IdResponsable { get; set; }
        public string Estado { get; set; }

        public List<Responsable.Dominio.Responsable> Responsables { get; set; }
        public Estudiante.Dominio.Estudiante estudiante { get; set; }
        public PreMatricula(DateTime fecPrematricula, int idResponsable, string estado)
        {
            FecPrematricula = fecPrematricula;
            IdResponsable = idResponsable;
            Estado = estado;
        }

        public IReadOnlyList<string> CanCrear(PreMatricula prematricula)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(prematricula.FecPrematricula.ToString()))
                errors.Add("Campo Fecha de Prematricula vacio");
            if (prematricula.IdResponsable == 0)
                errors.Add("Campo identiificacion  del responsable  vacio");
            if (string.IsNullOrEmpty(prematricula.Estado))
                errors.Add("Campo Estado de prematricula vacio");
            return errors;
        }
    }
}
