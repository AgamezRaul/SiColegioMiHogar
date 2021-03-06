using BackEnd.Base;
using BackEnd.Periodo.Dominio.Repositories;

namespace BackEnd.Periodo.Infra
{
    public class PeriodoServiceRepository : GenericRepository<Dominio.Periodo>, IPeriodoServiceRepository
    {
        public PeriodoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
