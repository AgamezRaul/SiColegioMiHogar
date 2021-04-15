using BackEnd.Base;
using BackEnd.Periodo.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Periodo.Infra
{
    public class PeriodoServiceRepository : GenericRepository<Dominio.Periodo>, IPeriodoServiceRepository
    {
        public PeriodoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
