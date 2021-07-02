using BackEnd.Base;
using BackEnd.Materia.Dominio.Repositories;

namespace BackEnd.Materia.Infra
{
    public class MateriaServiceRepository : GenericRepository<Dominio.Entidades.Materias>, IMateriaServiceRepository
    {
        public MateriaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
