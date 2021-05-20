using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Estudiante.Dominio;
using BackEnd.Usuario.Dominio;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private UnitOfWork _unitOfWork;

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
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet]
        public IEnumerable<Estudiante> Estudiantes()
        {
            return _context.Estudiante;

        }
    }
}
