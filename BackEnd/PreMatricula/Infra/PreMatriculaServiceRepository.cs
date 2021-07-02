using BackEnd.Base;
using BackEnd.PreMatricula.Dominio.Repositories;

namespace BackEnd.PreMatricula.Infra
{
    public class PreMatriculaServiceRepository : GenericRepository<Dominio.PreMatricula>, IPreMatriculaServiceRepository
    {
        public PreMatriculaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
