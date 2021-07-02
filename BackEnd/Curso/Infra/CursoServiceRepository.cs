using BackEnd.Base;
using BackEnd.Curso.Dominio.Repositories;

namespace BackEnd.Curso.Infra
{
    public class CursoServiceRepository : GenericRepository<Dominio.Curso>, ICursoServiceRepository
    {
        public CursoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}

