using BackEnd.Base;
using BackEnd.Contrato.Dominio;

namespace BackEnd.Contrato.Infra
{
    public class ContratoServiceRepository : GenericRepository<Dominio.Contrato>, IContratoServiceRepository
    {
        public ContratoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
