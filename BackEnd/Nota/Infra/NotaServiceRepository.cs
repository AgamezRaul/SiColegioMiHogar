using BackEnd.Base;
using BackEnd.Nota.Dominio.Repositories;

namespace BackEnd.Nota.Infra
{
    public class NotaServiceRepository : GenericRepository<Dominio.Entidades.Nota>, INotaServiceRepository
    {
        public NotaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}