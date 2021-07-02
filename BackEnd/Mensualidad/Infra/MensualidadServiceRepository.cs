using BackEnd.Base;
using BackEnd.Mensualidad.Dominio.Repositories;

namespace BackEnd.Mensualidad.Infra
{
    public class MensualidadServiceRepository : GenericRepository<Dominio.Mensualidad>, IMensualidadServiceRepository
    {
        public MensualidadServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
