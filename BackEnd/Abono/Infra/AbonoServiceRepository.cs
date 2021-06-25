using BackEnd.Abono.Dominio.Repositories;
using BackEnd.Base;

namespace BackEnd.Abono.Infra
{
    public class AbonoServiceRepository : GenericRepository<Dominio.Abono>, IAbonoServiceRepository
    {
        public AbonoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
