using BackEnd.Base;
using BackEnd.Contrato.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Contrato.Infra
{
    public class ContratoServiceRepository : GenericRepository<Dominio.Contrato>, IContratoServiceRepository
    {
        public ContratoServiceRepository(IDbContext context) : base(context)
        { 
        }
    }
}
