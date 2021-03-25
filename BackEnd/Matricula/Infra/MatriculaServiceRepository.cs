using BackEnd.Base;
using BackEnd.Matricula.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Matricula.Infra
{
    class MatriculaServiceRepository : GenericRepository<Dominio.Matricula>, IMatriculaServiceRepository
    {
        public MatriculaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
