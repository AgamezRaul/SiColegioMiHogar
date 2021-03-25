using BackEnd.Base;
using BackEnd.PreMatricula.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.PreMatricula.Infra
{
    public class PreMatriculaServiceRepository : GenericRepository<Dominio.PreMatricula>, IPreMatriculaServiceRepository
    {
        public PreMatriculaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
