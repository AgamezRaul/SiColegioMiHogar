using BackEnd;
using BackEnd.Base;
using BackEnd.materias.Aplicacion.Request;
using BackEnd.materias.Aplicacion.Services.Crear;
using BackEnd.Materia.Aplicacion.Services.Consultar;
using BackEnd.materias.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : Controller
    {
        private readonly MiHogarContext _context;
        private CrearMateriaService _service;
        //private ActualizarMateriaService _actualizarService;  genera errores
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
        public async Task<IActionResult> GeMaterias([FromRoute] int Id)
        {
            Materias materias = await _context.Materia.SingleOrDefaultAsync(t => t.Id == Id);
            if (materias == null)
                return NotFound();
            return Ok(materias);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterias([FromBody] CrearMateriaRequest materias)
        {
            _service = new CrearMateriaService(_unitOfWork);
            var rta = _service.Ejecutar(materias);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                //preguntar por lo que esta denteo del new
                return CreatedAtAction("GetMateria", new { id = materias.Id }, materias);
            }
            return BadRequest(rta.Message);
        }

        /*         actualizar pero aun presenta errores
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensualidad([FromRoute] int id, [FromBody] ActualizarMateriaRequest materias)
        {
            _actualizarService = new ActualizarMensualidadService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(mensualidad);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMensualidad", new { mes = mensualidad.Mes }, mensualidad);
            }
            return BadRequest(rta.Message);
        }*/
    }
}
