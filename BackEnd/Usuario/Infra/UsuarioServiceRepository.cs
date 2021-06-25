using BackEnd.Base;
using BackEnd.Usuario.Dominio.Repositories;

namespace BackEnd.Usuario.Infra
{
    public class UsuarioServiceRepository : GenericRepository<Dominio.Usuario>, IUsuarioServiceRepository
    {
        public UsuarioServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
