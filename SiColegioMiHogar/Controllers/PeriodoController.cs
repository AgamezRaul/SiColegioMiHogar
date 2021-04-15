using BackEnd;
using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;
using BackEnd.Periodo.Aplicacion.Services;
using BackEnd.Periodo.Dominio;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PeriodoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearPeriodoService _service;
        //private ActualizarMateriaService _actualizarService;  genera errores
        private UnitOfWork _unitOfWork;

        public PeriodoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        public PeriodoResponse PeriodoResponse;

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePeriodo([FromBody] PeriodoRequest periodo)
        {
            PeriodoResponse = new PeriodoResponse();

            _service = new CrearPeriodoService(_unitOfWork);

            var rta = _service.CrearPerido(periodo);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPeriodo", new { periodo = periodo.NumeroPeriodo }, periodo);
            }
            return BadRequest(rta.Message);
        }

        [HttpGet("[action]")]
        public IEnumerable<Periodo> Periodos()
        {
            ConsultarPeriodosService servicio = new ConsultarPeriodosService(_unitOfWork);
            List<Periodo> Lista = servicio.GetAll();
            return Lista;

        }
    }
}
