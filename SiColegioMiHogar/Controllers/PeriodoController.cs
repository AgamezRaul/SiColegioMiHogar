using BackEnd;
using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;
using BackEnd.Periodo.Aplicacion.Services;
using BackEnd.Periodo.Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PeriodoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearPeriodoService _service;
        private UnitOfWork _unitOfWork;

        public PeriodoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Periodo> GetPeriodos()
        {
            return _context.Periodo;

        }

        [HttpPost]
        public async Task<IActionResult> CreatePeriodo([FromBody] CrearPeriodoRequest periodo)
        {
            _service = new CrearPeriodoService(_unitOfWork);
            var rta = _service.Ejecutar(periodo);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { NumeroPeriodo = periodo.NumeroPeriodo }, periodo);
            }
            return BadRequest(rta.Message);
        }


        [HttpGet("[action]")]
        public Periodo GetPeriodo(int id)
        {
            ConsultarPeriodoService service = new ConsultarPeriodoService(_unitOfWork);
            return service.GetPeriodo(id);
        }


        [HttpDelete("[action]")]
        public ActionResult<EliminarPeriodoResponse> DeletePeriodo(int id)
        {
            EliminarPeriodoService service = new EliminarPeriodoService(_unitOfWork);
            EliminarPeriodoResponse response = service.DeletePeridodo(id);
            return Ok(response);
        }


        [HttpPut("[action]")]
        public ActionResult<ActualizarPeriodoResponse> ActualizarPeriodo([FromBody] CrearPeriodoRequest request)
        {
            ActualizarPeriodoService service = new ActualizarPeriodoService(_unitOfWork);
            ActualizarPeriodoResponse response = service.ActualizarPeriodo(request);
            return Ok(response);
        }

    }
}
