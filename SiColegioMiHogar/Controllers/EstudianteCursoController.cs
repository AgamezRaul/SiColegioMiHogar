using BackEnd;
using BackEnd.Base;
using BackEnd.Curso.Dominio;
using BackEnd.Estudiante.Dominio;
using BackEnd.EstudianteCurso.Aplicacion;
using BackEnd.EstudianteCurso.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteCursoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearEstudianteCursoService _crearService;
        private readonly ActualizarEstudianteCursoService _actualizarService;
        private readonly EliminarEstudianteCursoService _eliminarService;

        public UnitOfWork UnitOfWork => _unitOfWork;

        public EstudianteCursoController(MiHogarContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearEstudianteCursoService(_unitOfWork);
            _actualizarService = new ActualizarEstudianteCursoService(_unitOfWork);
            _eliminarService = new EliminarEstudianteCursoService(_unitOfWork);
        }
        [HttpGet]
        public IEnumerable<EstudianteCurso> GetEstudiantesCursos()
        {
            return _context.EstudianteCurso;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudianteCurso([FromRoute] int id)
        {
            EstudianteCurso estudianteCurso = await _context.EstudianteCurso.SingleOrDefaultAsync(t => t.Id == id);
            if (estudianteCurso == null)
                return NotFound();
            return Ok(estudianteCurso);
        }
        [HttpGet("EstudianteGrado/{grado}")]
        public object GetEstudianteGrado([FromRoute] string grado)
        {
            var result = (from e in _context.Set<Estudiante>()
                          where !(
                          from c in _context.Set<EstudianteCurso>()
                          select c.IdEstudiante).Contains(e.Id)
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

        [HttpGet("CursoGrado/{grado}")]
        public IQueryable<Curso> GetCursoGrado([FromRoute] string grado)
        {
            var cursos = _context.Curso.Where(t => t.Nombre == grado);
            return cursos;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstudianteCurso([FromBody] List<EstudianteCursoRequest> requests)
        {
            var rta = _crearService.Ejecutar(requests);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEstudianteCurso", requests);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut]
        public async Task<IActionResult> PutEstudianteCurso([FromBody] EstudianteCursoRequest request)
        {

            var rta = _actualizarService.Ejecutar(request);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEstudianteCurso", request);
            }
            return BadRequest(rta.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudianteCurso([FromRoute] int id)
        {
            var rta = _eliminarService.Ejecutar(id);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEstudianteCurso", id);
            }
            return BadRequest(rta.Message);
        }
    }
}
