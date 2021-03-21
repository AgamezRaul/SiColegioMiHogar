using BackEnd.Base;
using BackEnd.Estudiante.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Estudiante.Infra
{
    public class EstudianteServiceRepository : GenericRepository<Dominio.Estudiante>, IEstudianteServiceRepository
    {
        public EstudianteServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
