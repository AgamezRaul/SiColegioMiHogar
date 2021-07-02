using BackEnd.Base;
using BackEnd.EstudianteCurso.Dominio;

namespace BackEnd.EstudianteCurso.Infra
{
    public class EstudianteCursoServiceRepository : GenericRepository<Dominio.EstudianteCurso>, IEstudianteCursoServiceRepository
    {
        public EstudianteCursoServiceRepository(IDbContext context) : base(context) { }
    }
}
