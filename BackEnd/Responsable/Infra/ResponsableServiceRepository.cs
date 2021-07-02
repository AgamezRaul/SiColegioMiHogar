using BackEnd.Base;
using BackEnd.Responsable.Dominio.Repositories;

namespace BackEnd.Responsable.Infra
{
    public class ResponsableServiceRepository : GenericRepository<Dominio.Responsable>, IResponsableServiceRepository
    {
        public ResponsableServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
