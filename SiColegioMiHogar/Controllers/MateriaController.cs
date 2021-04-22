using BackEnd;
using BackEnd.Base;
using BackEnd.Materia.Aplicacion.Request;
using BackEnd.Materia.Aplicacion.Services.Actualizar;
using BackEnd.Materia.Aplicacion.Services.Crear;
using BackEnd.Materia.Aplicacion.Services.Eliminar;
using BackEnd.Materia.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : Controller
    {
        private readonly MiHogarContext _context;
        private CrearMateriaService _service;
        private ActualizarMateriaService _actualizarService;
        private EliminarMateriaService _eliminarService;
        private UnitOfWork _unitOfWork;

        public MateriaController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
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

        [HttpPost]
        public async Task<IActionResult> CreateMaterias([FromBody] CrearMateriaRequest request)
        {
            _service = new CrearMateriaService(_unitOfWork);
            var rta = _service.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMateria", new { idDocente = request.IdDocente }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria([FromRoute] string id, [FromBody] ActualizarMateriaRequest request)
        {
            _actualizarService = new ActualizarMateriaService(_unitOfWork);
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
            _eliminarService = new EliminarMateriaService(_unitOfWork);
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
