using BackEnd;
using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service.Actualizar;
using BackEnd.Mensualidad.Aplicacion.Service.Crear;
using BackEnd.Mensualidad.Dominio;
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
    public class MensualidadController : Controller
    {
        private readonly MiHogarContext _context;
        private CrearMensualidadService _service;
        private ActualizarMensualidadService _actualizarService;
        private UnitOfWork _unitOfWork;
        public MensualidadController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Mensualidad> GetMensualidades()
        {
            return _context.Mensualidad;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMensualidad([FromRoute] string mes)
        {
            Mensualidad mensualidad = await _context.Mensualidad.SingleOrDefaultAsync(t => t.Mes == mes);
            if (mensualidad == null)
                return NotFound();
            return Ok(mensualidad);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMensualidad([FromBody] CrearMensualidadRequest mensualidad)
        {
            _service = new CrearMensualidadService(_unitOfWork);
            var rta = _service.Ejecutar(mensualidad);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                //preguntar por lo que esta denteo del new
                return CreatedAtAction("GetMensualidad", new { mes = mensualidad.Mes }, mensualidad);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensualidad([FromRoute] int id, [FromBody] ActualizarMensualidadRequest mensualidad)
        {
            _actualizarService = new ActualizarMensualidadService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(mensualidad);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMensualidad", new { mes = mensualidad.Mes }, mensualidad);
            }
            return BadRequest(rta.Message);
        }
        
      
       
        /* public IActionResult Index()
         {
             return View();
         }*/
    }
}
