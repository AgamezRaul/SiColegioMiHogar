using BackEnd.Base;
using BackEnd.Estudiante.Dominio.Repositories;

namespace BackEnd.Estudiante.Infra
{
    public class EstudianteServiceRepository : GenericRepository<Dominio.Estudiante>, IEstudianteServiceRepository
    {
        public EstudianteServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
