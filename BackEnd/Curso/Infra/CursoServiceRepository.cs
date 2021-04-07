using BackEnd.Base;
using BackEnd.Curso.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Curso.Infra
{
    public class CursoServiceRepository : GenericRepository<Dominio.Curso>, ICursoServiceRepository
    {
        public CursoServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}

