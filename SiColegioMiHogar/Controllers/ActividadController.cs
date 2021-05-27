using BackEnd;
using BackEnd.Actividad;
using BackEnd.Actividad.Aplicacion;
using BackEnd.Base;
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
    public class ActividadController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly CrearActividadService _crearService;
        private readonly ActualizarActividadService _actualizarService;
        private readonly EliminarActividadService _eliminarService;
        public ActividadController(MiHogarContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearActividadService(_unitOfWork);
            _actualizarService = new ActualizarActividadService(_unitOfWork);
            _eliminarService = new EliminarActividadService(_unitOfWork);
        }
        [HttpGet]
        public IEnumerable<Actividad> GetActividades()
        {
            return _context.Actividad;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActividad([FromRoute] int id)
        {
            Actividad actividad = await _context.Actividad.SingleOrDefaultAsync(t => t.Id == id);
            if (actividad == null)
                return NotFound();
            return Ok(actividad);
        }
        [HttpPost]
        public async Task<IActionResult> CreateActividad([FromBody] CrearActividadRequest request)
        {
            var rta = _crearService.EjecutarCrearActividad(request);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetActividad", request);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut]
        public async Task<IActionResult> PutContrato([FromBody] ActualizarActividadRequest request)
        {

            var rta = _actualizarService.EjecutarActualizarActividad(request);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetActividad", request);
            }
            return BadRequest(rta.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato([FromRoute] int id)
        {
            var rta = _eliminarService.EjecutarEliminar(id);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetActividad", id);
            }
            return BadRequest(rta.Message);
        }

        [HttpGet("[action]")]
        public List<Actividad> GetActividadesMateria(int idMateria)
        {
            ConsultarActividadesMateriaService service = new ConsultarActividadesMateriaService(_unitOfWork);
            return service.GetActividades(idMateria);
        }
    }
}
