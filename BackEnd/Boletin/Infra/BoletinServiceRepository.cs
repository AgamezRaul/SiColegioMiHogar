using BackEnd.Base;
using BackEnd.Boletin.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Boletin.Infra
{
    public class BoletinServiceRepository: GenericRepository<Dominio.Boletin>, IBoletinServiceRepository
    {
        public BoletinServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
