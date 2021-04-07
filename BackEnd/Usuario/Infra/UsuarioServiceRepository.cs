using BackEnd.Base;
using BackEnd.Usuario.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Infra
{
   public class UsuarioServiceRepository : GenericRepository<Dominio.Usuario>, IUsuarioServiceRepository
    {
        public UsuarioServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
