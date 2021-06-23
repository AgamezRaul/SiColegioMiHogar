using BackEnd.Abono.Dominio.Repositories;
using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Abono.Infra
{
    public class AbonoServiceRepository : GenericRepository<Dominio.Abono>, IAbonoServiceRepository
    {
        public AbonoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
