using BackEnd.Base;
using BackEnd.ValorMensualidad.Dominio.Repositories;

namespace BackEnd.ValorMensualidad.Infra
{
    public class ValorMensualidadServiceRepository : GenericRepository<Dominio.ValorMensualidad>, IValorMensualidadServiceRepository
    {
        public ValorMensualidadServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
