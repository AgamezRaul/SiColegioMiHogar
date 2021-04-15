using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Base;
using BackEnd.Nota.Dominio.Repositories;

namespace BackEnd.Nota.Infra
{
    public class NotaServiceRepository : GenericRepository<Dominio.Entidades.Nota>, InotaServiceRepository
    {
        public NotaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}