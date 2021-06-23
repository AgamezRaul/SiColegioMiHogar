using BackEnd.Base;
using BackEnd.ValorMensualidad.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.ValorMensualidad.Infra
{
   public  class ValorMensualidadServiceRepository : GenericRepository<Dominio.ValorMensualidad>, IValorMensualidadServiceRepository
    {
        public ValorMensualidadServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
