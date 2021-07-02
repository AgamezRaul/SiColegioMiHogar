using BackEnd.Base;

namespace BackEnd.EstudianteCurso.Dominio
{
    public class EstudianteCurso : Entity<int>
    {
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }

        public EstudianteCurso(int idEstudiante, int idCurso)
        {
            IdEstudiante = idEstudiante;
            IdCurso = idCurso;
        }
    }
}
