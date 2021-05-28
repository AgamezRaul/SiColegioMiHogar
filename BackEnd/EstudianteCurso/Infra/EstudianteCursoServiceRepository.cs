using BackEnd.Base;
using BackEnd.EstudianteCurso.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.EstudianteCurso.Infra
{
    public class EstudianteCursoServiceRepository : GenericRepository<Dominio.EstudianteCurso>, IEstudianteCursoServiceRepository
    {
        public EstudianteCursoServiceRepository(IDbContext context) : base(context) { }
    }
}
