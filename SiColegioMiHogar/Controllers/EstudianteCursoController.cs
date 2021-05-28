using BackEnd;
using BackEnd.Base;
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
        public EstudianteCursoController(MiHogarContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearEstudianteCursoService(_unitOfWork);
            _actualizarService = new ActualizarEstudianteCursoService(_unitOfWork);
            _eliminarService = new EliminarEstudianteCursoService(_unitOfWork);
        }
        [HttpGet]
        public IEnumerable<EstudianteCurso> GetEstudianteCursos()
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
        [HttpPost]
        public async Task<IActionResult> CreateEstudianteCurso([FromBody] EstudianteCursoRequest request)
        {
            var rta = _crearService.Ejecutar(request);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEstudianteCurso", request);
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
