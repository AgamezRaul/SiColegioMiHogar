using BackEnd;
using BackEnd.Base;
using BackEnd.Docente.Dominio;
using BackEnd.Curso.Aplicacion.Request;
using BackEnd.Curso.Aplicacion.Service.Crear;
using BackEnd.Curso.Aplicacion.Service.Actualizar;
using BackEnd.Curso.Aplicacion.Service.Eliminar;
using BackEnd.Curso.Dominio;
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
    public class CursoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearCursoService _service;
        private ActualizarCursoService _actualizarService;
        private EliminarCursoService _eliminarService;
        private UnitOfWork _unitOfWork;

        public CursoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public Object GetCursos()
        {
            var result = (from c in _context.Set<Curso>()
                          join d in _context.Set<Docente>()
                          on c.IdDirectorDocente equals d.Id
                          select new
                          {
                              Id = c.Id,
                              NombreCurso = c.Nombre,
                              MaximoEstudiantes = c.MaxEstudiantes,
                              Docente = d.NombreCompleto
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpGet("GetCursoDocente/{id}")]
        public Object GetCursoDocente([FromRoute] int id)
        {
            var result = (from c in _context.Set<Curso>()
                          join d in _context.Set<Docente>()
                          on c.IdDirectorDocente equals d.Id
                          where c.Id == id
                          select new
                          {
                              IdCurso = c.Id,
                              NombreCurso = c.Nombre,
                              MaximoEstudiantes = c.MaxEstudiantes,
                              Docente = d.NombreCompleto,
                              IdDocente = d.Id,
                              CedulaDocente = d.Cedula
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurso([FromRoute] int id)
        {
            Curso curso = await _context.Curso.SingleOrDefaultAsync(t => t.Id == id);
            if (curso == null)
                return NotFound();
            return Ok(curso);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCurso([FromBody] CrearCursoRequest curso)
        {
            _service = new CrearCursoService(_unitOfWork);
            var rta = _service.Ejecutar(curso);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                //busaca en la base de datos para guardar
                return CreatedAtAction("GetCurso", new { id = curso.id }, curso);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso([FromRoute] int id, [FromBody] ActualizarCursoRequest curso)
        {
            _actualizarService = new ActualizarCursoService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(curso);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCurso", new { id = curso.id }, curso);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso([FromRoute] int id)
        {
            _eliminarService = new EliminarCursoService(_unitOfWork);
            EliminarCursoRequest request = new EliminarCursoRequest();
            request.IdCurso = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCurso", new { id = request.IdCurso }, request);

            }
            return BadRequest(rta.Message);
        }
    }
}
