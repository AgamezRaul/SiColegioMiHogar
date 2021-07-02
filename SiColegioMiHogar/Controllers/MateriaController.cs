using BackEnd;
using BackEnd.Base;
using BackEnd.Docente.Dominio;
using BackEnd.EstudianteCurso.Dominio;
using BackEnd.Materia.Aplicacion.Request;
using BackEnd.Materia.Aplicacion.Services.Actualizar;
using BackEnd.Materia.Aplicacion.Services.Crear;
using BackEnd.Materia.Aplicacion.Services.Eliminar;
using BackEnd.Materia.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : Controller
    {
        private readonly MiHogarContext _context;
        private readonly CrearMateriaService _service;
        private readonly ActualizarMateriaService _actualizarService;
        private readonly EliminarMateriaService _eliminarService;
        private readonly UnitOfWork _unitOfWork;

        public MateriaController(MiHogarContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _service = new CrearMateriaService(_unitOfWork);
            _actualizarService = new ActualizarMateriaService(_unitOfWork);
            _eliminarService = new EliminarMateriaService(_unitOfWork);
        }

        [HttpGet("materiasEstudiante/{idEstudiante}")]
        public object GetMateriasEstudiante(int idEstudiante)
        {
            var result = (from m in _context.Set<Materias>()
                          join ec in _context.Set<EstudianteCurso>()
                          on m.IdCurso equals ec.IdCurso
                          where ec.IdEstudiante == idEstudiante
                          select new
                          {
                              m.Id,
                              m.IdDocente,
                              m.IdCurso,
                              m.NombreMateria
                          }).ToList();
            return result;
        }

        [HttpGet]
        public IEnumerable<Materias> GetMaterias()
        {
            return _context.Materia;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateria([FromRoute] int id)
        {
            Materias materias = await _context.Materia.SingleOrDefaultAsync(t => t.Id == id);
            if (materias == null)
                return NotFound();
            return Ok(materias);
        }

        [HttpGet("materiaDocente/{correo}")]
        public object GetMateriaDocente([FromRoute] string correo)
        {
            var result = (from m in _context.Set<Materias>()
                          join d in _context.Set<Docente>()
                          on m.IdDocente equals d.Id
                          where d.Correo == correo
                          select new
                          {
                              m.Id,
                              m.NombreMateria,
                              m.IdCurso,
                              m.IdDocente
                          }).ToList();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterias([FromBody] CrearMateriaRequest request)
        {
            var rta = _service.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMateria", new { idDocente = request.IdDocente }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria([FromRoute] int id, [FromBody] ActualizarMateriaRequest request)
        {
            var rta = _actualizarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMateria", new { id = request.Id }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreMatricula([FromRoute] int id)
        {
            EliminarMateriaRequest request = new EliminarMateriaRequest();
            request.Id = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMateria", new { id = request.Id }, request);
            }
            return BadRequest(rta.Message);
        }
    }
}
