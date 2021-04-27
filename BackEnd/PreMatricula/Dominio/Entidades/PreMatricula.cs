using BackEnd.Base;
using System;
using System.Collections.Generic;

namespace BackEnd.PreMatricula.Dominio
{
    public class PreMatricula : Entity<int>
    {
       

        public DateTime FecPrematricula { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }

        public List<Responsable.Dominio.Responsable> Responsables { get; set; }
        public Estudiante.Dominio.Estudiante estudiante { get; set; }
        public PreMatricula() { }
        public PreMatricula(DateTime fecPrematricula, int idUsuario, string estado)
        {
            FecPrematricula = fecPrematricula;
            IdUsuario = idUsuario;
            Estado = estado;
        }
    }
}
