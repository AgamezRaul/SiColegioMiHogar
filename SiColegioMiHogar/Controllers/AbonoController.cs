using BackEnd;
using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Abono.Aplicacion.Service.Actualizar;
using BackEnd.Abono.Aplicacion.Service.Anular;
using BackEnd.Abono.Aplicacion.Service.Crear;
using BackEnd.Abono.Dominio;
using BackEnd.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearAbonoService _service;
        private ActualizarAbonoService _actualizarService;
        private AnularAbonoService _anularService;
        private UnitOfWork _unitOfWork;
        public AbonoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbono([FromRoute] int id)
        {
            Abono abono = await _context.Abono.SingleOrDefaultAsync(t => t.Id == id);
            if (abono == null)
                return NotFound();
            return Ok(abono);
        }*/
        [HttpPost]
        public async Task<IActionResult> CreateAbono([FromBody] CrearAbonoRequest abono)
        {
            _service = new CrearAbonoService(_unitOfWork);
            var rta = _service.Ejecutar(abono);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAbono", new { id = abono.id }, abono);
            }
            return BadRequest(rta.Message);
        }


        [HttpPut("PutAnular/{id}")]
        public async Task<IActionResult> PutAnular([FromRoute] int id)
        {
            _anularService = new AnularAbonoService(_unitOfWork);
            AnularAbonoRequest request = new AnularAbonoRequest();
            request.id = id;
            var rta = _anularService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAbono", new { id = request.id }, request);
            }
            return Ok(rta);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbono([FromRoute] int id, [FromBody] ActualizarAbonoRequest abono)
        {
            _actualizarService = new ActualizarAbonoService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(abono);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAbono", new { id = abono.id }, abono);
            }
            return BadRequest(rta.Message);
        }
    }
}
