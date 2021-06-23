using BackEnd.Base;
using BackEnd.Grado.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Grado.Infra
{
   public class GradoServiceRepository : GenericRepository<Dominio.Grado>, IGradoServiceRepository
    {
        public GradoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
