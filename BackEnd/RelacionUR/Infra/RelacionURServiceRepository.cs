using BackEnd.Base;
using BackEnd.RelacionUR.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.RelacionUR.Infra
{
   public class RelacionURServiceRepository : GenericRepository<Dominio.RelacionUR>, IRelacionURServiceRepository
    {
        public RelacionURServiceRepository(IDbContext context) : base(context)
        {

        }
    }
}
