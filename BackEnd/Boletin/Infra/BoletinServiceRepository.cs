using BackEnd.Base;
using BackEnd.Boletin.Dominio.Repositories;

namespace BackEnd.Boletin.Infra
{
    public class BoletinServiceRepository : GenericRepository<Dominio.Boletin>, IBoletinServiceRepository
    {
        public BoletinServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
