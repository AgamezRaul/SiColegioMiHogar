using BackEnd.Base;
using BackEnd.NotaPeriodo.Dominio.Repositories;

namespace BackEnd.NotaPeriodo.Infra
{
    public class NotaPeriodoServiceRepository : GenericRepository<Dominio.NotaPeriodo>, INotaPeriodoServiceRepository
    {
        public NotaPeriodoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
