using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Base;
using BackEnd.materias.Dominio.Repositories;

namespace BackEnd.materias.Infra
{
    public class MateriaServiceRepository : GenericRepository<Dominio.Entidades.Materias>, IMateriaServiceRepository
    {
        public MateriaServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
