using BackEnd;
using BackEnd.Base;
using BackEnd.Docente.Aplicacion.Request;
using BackEnd.Docente.Aplicacion.Service.Actualizar;
using BackEnd.Docente.Aplicacion.Service.Crear;
using BackEnd.Docente.Dominio;
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
    public class DocenteController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearDocenteService _service;
        private ActualizarDocenteService _actualizarService;
        private UnitOfWork _unitOfWork;

        public DocenteController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public Object GetDocentes()
        {
            var result = (from c in _context.Set<Docente>()
                          select new
                          {
                              Id = c.Id,
                              NombreCompleto = c.NombreCompleto,
                              NumTarjetaProf = c.NumTarjetaProf,
                              Cedula= c.Cedula,
                              Celular=c.Celular,
                              Correo = c.Correo
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocente([FromRoute] int id)
        {
            Docente docente = await _context.Docente.SingleOrDefaultAsync(t => t.Id == id);
            if (docente == null)
                return NotFound();
            return Ok(docente);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDocente([FromBody] CrearDocenteRequest docente)
        {
            _service = new CrearDocenteService(_unitOfWork);
            var rta = _service.Ejecutar(docente);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                //busaca en la base de datos para guardar
                return CreatedAtAction("GetDocente", new { id = docente.id }, docente);
            }
            return BadRequest(rta.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocente([FromRoute] int id, [FromBody] ActualizarDocenteRequest docente)
        {
            _actualizarService = new ActualizarDocenteService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(docente);
            if (rta != null)
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetDocente", new { id = docente.id }, docente);
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
