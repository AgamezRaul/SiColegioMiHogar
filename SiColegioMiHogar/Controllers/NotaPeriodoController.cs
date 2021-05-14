using BackEnd;
using BackEnd.Base;
using BackEnd.Periodo.Dominio;
using BackEnd.Materia.Dominio;
using BackEnd.NotaPeriodo.Aplicacion.Request;
using BackEnd.NotaPeriodo.Aplicacion.Service.Crear;
using BackEnd.NotaPeriodo.Aplicacion.Service.Actualizar;
using BackEnd.NotaPeriodo.Aplicacion.Service.Eliminar;
using BackEnd.NotaPeriodo.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Materia.Dominio.Entidades;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaPeriodoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearNotaPeriodoService _service;
        private ActualizarNotaPeriodoService _actualizarService;
        private EliminarNotaPeriodoService _eliminarService;
        private UnitOfWork _unitOfWork;

        public NotaPeriodoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public Object GetNotasPeriodos()
        {
            var result = (from c in _context.Set<NotaPeriodo>()
                          join d in _context.Set<Periodo>()
                          on c.IdPeriodo equals d.Id
                          join m in _context.Set<Materias>()
                          on c.IdMateria equals m.Id
                          select new
                          {
                              Id = c.Id,
                              Nota = c.Nota,
                              Observacion = c.Observacion,
                              IdPeriodo = c.IdPeriodo,
                              NombrePeriodo = d.NombrePeriodo,
                              IdMateria = c.IdMateria,
                              NombreMateria = m.NombreMateria
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpGet("GetNotaPeriodoMateriaPeriodo/{id}")]
        public Object GetNotaPeriodoMateriaPeriodo([FromRoute] int id)
        {
            var result = (from c in _context.Set<NotaPeriodo>()
                          join d in _context.Set<Periodo>()
                          on c.IdPeriodo equals d.Id
                          join m in _context.Set<Materias>()
                          on c.IdMateria equals m.Id
                          where c.Id == id
                          select new
                          {
                              Id = c.Id,
                              Nota = c.Nota,
                              Observacion = c.Observacion,
                              IdPeriodo = c.IdPeriodo,
                              NombrePeriodo = d.NombrePeriodo,
                              IdMateria = c.IdMateria,
                              NombreMateria = m.NombreMateria
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotaPeriodo([FromRoute] int id)
        {
            NotaPeriodo notaPeriodo = await _context.NotaPeriodo.SingleOrDefaultAsync(t => t.Id == id);
            if (notaPeriodo == null)
                return NotFound();
            return Ok(notaPeriodo);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotaPeriodo([FromBody] CrearNotaPeriodoRequest notaPeriodo)
        {
            _service = new CrearNotaPeriodoService(_unitOfWork);
            var rta = _service.Ejecutar(notaPeriodo);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                //busaca en la base de datos para guardar
                return CreatedAtAction("GetNotaPeriodo", new { id = notaPeriodo.id }, notaPeriodo);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotaPeriodo([FromRoute] int id, [FromBody] ActualizarNotaPeriodoRequest request)
        {
            _actualizarService = new ActualizarNotaPeriodoService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetNotaPeriodo", new { id = request.id }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaPeriodo([FromRoute] int id)
        {
            _eliminarService = new EliminarNotaPeriodoService(_unitOfWork);
            EliminarNotaPeriodoRequest request = new EliminarNotaPeriodoRequest();
            request.IdNotaPeriodo = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetNotaPeriodo", new { id = request.IdNotaPeriodo }, request);

            }
            return BadRequest(rta.Message);
        }
    }
}
