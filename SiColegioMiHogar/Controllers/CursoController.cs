using BackEnd;
using BackEnd.Base;
using BackEnd.Curso.Aplicacion.Request;
using BackEnd.Curso.Aplicacion.Service.Actualizar;
using BackEnd.Curso.Aplicacion.Service.Crear;
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
    public class CursoController : Controller
    {
        private readonly MiHogarContext _context;
        private CrearCursoService _service;
        private ActualizarCursoService _actualizarService;
        private UnitOfWork _unitOfWork;
        public CursoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Curso> GetCurso()
        {
            return _context.Curso;
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
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutCurso([FromRoute] int id, [FromBody] ActualizarCursoRequest curso)
        {
            _actualizarService = new ActualizarCursoService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(curso);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCurso", new { mes = curso.Mes }, mensualidad);
            }
            return BadRequest(rta.Message);
        }*/
    }
}
