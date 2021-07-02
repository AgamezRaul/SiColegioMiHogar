using BackEnd.Base;
using BackEnd.Grado.Dominio.Repositories;

namespace BackEnd.Grado.Infra
{
    public class GradoServiceRepository : GenericRepository<Dominio.Grado>, IGradoServiceRepository
    {
        public GradoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
