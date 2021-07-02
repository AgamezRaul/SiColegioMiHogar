using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Dominio;
using BackEnd.EstudianteCurso.Dominio;
using BackEnd.Materia.Dominio.Entidades;
using BackEnd.Usuario.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly UnitOfWork _unitOfWork;

        public EstudianteController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet("GetEstudianteUsuarios")]
        public Object GetDocenteUsuarios()
        {
            var result = (from c in _context.Set<Estudiante>()
                          where !(
                          from u in _context.Set<Usuario>()
                          select u.Correo).Contains(c.Correo)
                          select new
                          {
                              c.Id,
                              c.IdeEstudiante,
                              c.NomEstudiante,
                              c.Correo,
                              c.IdUsuario
                          }).ToList();
            return result;
        }

        [HttpGet("GetEstudianteCurso/{idMateria}")]
        public object GetEstudianteCurso([FromRoute] int idMateria)
        {
            var result = (from e in _context.Set<Estudiante>()
                          join ec in _context.Set<EstudianteCurso>()
                          on e.Id equals ec.IdEstudiante
                          join m in _context.Set<Materias>()
                          on ec.IdCurso equals m.IdCurso
                          where m.Id == idMateria
                          select new
                          {
                              e.Id,
                              e.IdeEstudiante,
                              e.NomEstudiante,
                              e.FecNacimiento,
                              e.LugNacimiento,
                              e.LugExpedicion,
                              e.InsProcedencia,
                              e.DirResidencia,
                              e.CelEstudiante,
                              e.TipSangre,
                              e.GradoEstudiante,
                              e.Eps,
                              e.Correo,
                              e.Sexo,
                              e.TipoDocumento,
                              e.TelEstudiante,
                              e.IdUsuario
                          }).ToList();
            return result;
        }

        [HttpGet("UsuarioEstudiante/{correo}")]
        public Estudiante GetUsuarioEstudiante(string correo)
        {
            return _context.Estudiante.FirstOrDefault(t => t.Correo == correo);
        }

        [HttpGet]
        public IEnumerable<Estudiante> Estudiantes()
        {
            return _context.Estudiante;

        }

    }
}
