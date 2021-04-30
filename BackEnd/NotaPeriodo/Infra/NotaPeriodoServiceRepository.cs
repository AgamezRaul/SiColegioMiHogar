using BackEnd.Base;
using BackEnd.NotaPeriodo.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.NotaPeriodo.Infra
{
    public class NotaPeriodoServiceRepository : GenericRepository<Dominio.NotaPeriodo>, INotaPeriodoServiceRepository
    {
        public NotaPeriodoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
