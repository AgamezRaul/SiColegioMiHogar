using BackEnd;
using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;
using BackEnd.Contrato.Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly CrearContratoService _crearService;

        public ContratoController(MiHogarContext context)
        {
            this._context = context;
            UnitOfWork _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearContratoService(_unitOfWork);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrematricula([FromBody] CrearContratoRequest request)
        {
            var rta = _crearService.EjecutarCrearContrato(request);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPreMatricula", new { Id = request.IdDocente }, request);
            }
            return BadRequest(rta.Message);
        }
    }
}
