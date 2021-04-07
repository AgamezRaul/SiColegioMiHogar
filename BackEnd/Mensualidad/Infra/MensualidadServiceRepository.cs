using BackEnd.Base;
using BackEnd.Mensualidad.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Mensualidad.Infra
{
    public class MensualidadServiceRepository : GenericRepository<Dominio.Mensualidad>, IMensualidadServiceRepository
    {
        public MensualidadServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
