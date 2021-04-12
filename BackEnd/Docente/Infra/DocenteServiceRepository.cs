using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Base;
using BackEnd.Docente.Dominio.Repositories;

namespace BackEnd.Docente.Infra
{
    class DocenteServiceRepository : GenericRepository<Dominio.Docente>, IDocenteServiceRepository
    {
        public DocenteServiceRepository(IDbContext context) : base(context)
    {
    }
}
}
