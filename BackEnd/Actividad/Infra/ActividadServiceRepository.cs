using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Actividad
{
    public class ActividadServiceRepository : GenericRepository<Actividad>, IActividadServiceRepository
    {
        public ActividadServiceRepository(IDbContext context) : base(context) { }
    }
}
