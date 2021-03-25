using BackEnd.Base;
using BackEnd.Responsable.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Responsable.Infra
{
   public class ResponsableServiceRepository : GenericRepository<Dominio.Responsable>, IResponsableServiceRepository
    {
        public ResponsableServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
