using BackEnd;
using BackEnd.Base;
using BackEnd.ValorMensualidad.Aplicacion.Request;
using BackEnd.ValorMensualidad.Aplicacion.Service.Actualizar;
using BackEnd.ValorMensualidad.Aplicacion.Service.Crear;
using BackEnd.ValorMensualidad.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValorMensualidadController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearValorMensualidadService _service;
        private ActualizarValorMensualidadService _actualizarService;
        private UnitOfWork _unitOfWork;

        public ValorMensualidadController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        [HttpGet]
        public object GetValorMensualidades()
        {
            var result = (from vm in _context.Set<ValorMensualidad>()
                          select new
                          {
                              id = vm.Id,
                              fecha = vm.Fecha,
                              precioMensualida = vm.PrecioMensualidad,
                              año = vm.Año,
                              idGrado = vm.IdGrado

                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValorMensualidad([FromRoute] int id)
        {
            ValorMensualidad valorMensualidad = await _context.ValorMensualidad.SingleOrDefaultAsync(t => t.Id == id);
            if (valorMensualidad == null)
                return NotFound();
            return Ok(valorMensualidad);
        }
        [HttpPost]
        public async Task<IActionResult> CreateValorMensualidad([FromBody] CrearValorMensualidadRequest valorMensualidad)
        {
            _service = new CrearValorMensualidadService(_unitOfWork);
            var rta = _service.Ejecutar(valorMensualidad);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetValorMensualidad", new { id = valorMensualidad.id }, valorMensualidad);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromRoute] int id, [FromBody] ActualizarValorMensualidadRequest valorMensualidad)
        {
            _actualizarService = new ActualizarValorMensualidadService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(valorMensualidad);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetValorMensualidad", new { id = valorMensualidad.id }, valorMensualidad);
            }
            return BadRequest(rta.Message);
        }

    }
}
