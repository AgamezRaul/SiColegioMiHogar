using System.Linq;
using System.Threading.Tasks;
using BackEnd;
using BackEnd.Base;
using BackEnd.Grado.Aplicacion.Request;
using BackEnd.Grado.Aplicacion.Service.Actualizar;
using BackEnd.Grado.Aplicacion.Service.Crear;
using BackEnd.Grado.Aplicacion.Service.Eliminar;
using BackEnd.Grado.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearGradoService _service;
        private ActualizarGradoService _actualizarService;
        private EliminarGradoService _eliminarService;
        private UnitOfWork _unitOfWork;
        public GradoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrado([FromRoute] int id)
        {
            Grado grado = await _context.Grado.SingleOrDefaultAsync(t => t.Id == id);
            if (grado == null)
                return NotFound();
            return Ok(grado);
        }
        [HttpGet]
        public object GetGrados()
        {
            var result = (from g in _context.Set<Grado>()
                          select new
                          {
                              id = g.Id,
                              nombre = g.Nombre
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }




        [HttpPost]
        public async Task<IActionResult> CreateGrado([FromBody] CrearGradoRequest grado)
        {
            _service = new CrearGradoService(_unitOfWork);
            var rta = _service.Ejecutar(grado);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetGrado", new { id = grado.id }, grado);
            }
            return BadRequest(rta.Message);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrado([FromRoute] int id)
        {
            _eliminarService = new EliminarGradoService(_unitOfWork);
            EliminarGradoRequest request = new EliminarGradoRequest();
            request.id = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetGrado", new { id = request.id }, request);
            }
            return Ok(rta);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrado([FromRoute] int id, [FromBody] ActualizarGradoRequest grado)
        {
            _actualizarService = new ActualizarGradoService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(grado);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetGrado", new { id = grado.id }, grado);
            }
            return BadRequest(rta.Message);
        }
    }
}
