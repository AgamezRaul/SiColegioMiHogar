using BackEnd.Base;

namespace BackEnd.Actividad
{
    public class ActividadServiceRepository : GenericRepository<Actividad>, IActividadServiceRepository
    {
        public ActividadServiceRepository(IDbContext context) : base(context) { }
    }
}
