using BackEnd.Base;
using BackEnd.Matricula.Dominio.Repositories;

namespace BackEnd.Matricula.Infra
{
    public class MatriculaServiceRepository : GenericRepository<Dominio.Matricula>, IMatriculaServiceRepository
    {
        public MatriculaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
