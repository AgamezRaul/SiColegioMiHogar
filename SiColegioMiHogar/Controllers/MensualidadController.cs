using System.Linq;
using System.Threading.Tasks;
using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Dominio;
using BackEnd.Grado.Dominio;
using BackEnd.Matricula.Dominio;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service;
using BackEnd.Mensualidad.Aplicacion.Service.Actualizar;
using BackEnd.Mensualidad.Aplicacion.Service.Crear;
using BackEnd.Mensualidad.Aplicacion.Service.Eliminar;
using BackEnd.Mensualidad.Dominio;
using BackEnd.PreMatricula.Dominio;
using BackEnd.Usuario.Dominio;
using BackEnd.ValorMensualidad.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensualidadController : Controller
    {
        private readonly MiHogarContext _context;
        private CrearMensualidadService _service;
        private ActualizarMensualidadService _actualizarService;
        private EliminarMensualidadService _eliminarService;
        private EviarEmailService _eviarEmail;
        private UnitOfWork _unitOfWork;
        public MensualidadController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public object GetMensualidades()
        {
            var result = (from m in _context.Set<Mensualidad>()
                          join ma in _context.Set<Matricula>()
                          on m.IdMatricula equals ma.Id
                          join p in _context.Set<PreMatricula>()
                           on ma.IdePreMatricula equals p.Id
                          join u in _context.Set<Usuario>()
                           on p.IdUsuario equals u.Id
                          join e in _context.Set<Estudiante>()
                          on p.IdUsuario equals e.IdUsuario
                          join g in _context.Set<Grado>()
                          on e.GradoEstudiante equals g.Nombre
                          join vm in _context.Set<ValorMensualidad>()
                          on g.Id equals vm.IdGrado
                          select new
                          {
                              Id = m.Id,
                              Estudiante = e.NomEstudiante,
                              Mes = m.Mes,
                              Anio = m.Año,
                              ValorMensualidad = vm.PrecioMensualidad,
                              //DescuentoMensualidad = m.DescuentoMensualidad,

                              Deuda = m.Deuda,
                              Estado = m.Estado,
                              //TotalMensualidad = m.TotalMensualidad,
                              Correo = u.Correo
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("GetMensualidadesMatricula/{id}")]
        public object GetMensualidadesMatricula([FromRoute] int id)
        {
            var result = (from m in _context.Set<Mensualidad>()
                          join ma in _context.Set<Matricula>()
                          on m.IdMatricula equals ma.Id
                          join p in _context.Set<PreMatricula>()
                           on ma.IdePreMatricula equals p.Id
                          join u in _context.Set<Usuario>()
                           on p.IdUsuario equals u.Id
                          join e in _context.Set<Estudiante>()
                          on p.IdUsuario equals e.IdUsuario
                          join g in _context.Set<Grado>()
                          on  e.GradoEstudiante equals g.Nombre
                          join vm in _context.Set<ValorMensualidad>()
                          on g.Id equals vm.IdGrado
                          where ma.Id == id
                          select new
                          {
                              Id = m.Id,
                              Estudiante = e.NomEstudiante,
                              Mes = m.Mes,
                              Anio = m.Año,
                              ValorMensualidad = vm.PrecioMensualidad,
                              Deuda = m.Deuda,
                              Estado = m.Estado,
                              Correo = u.Correo
                          }).ToList();
            return result;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetMensualidad([FromRoute] int id)
        {
            Mensualidad mensualidad = await _context.Mensualidad.SingleOrDefaultAsync(t => t.Id == id);
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
                return CreatedAtAction("GetMensualidad", new { Id = mensualidad.id }, mensualidad);
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
                return CreatedAtAction("GetMensualidad", new { id = mensualidad.id }, mensualidad);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensualidad([FromRoute] int id)
        {
            _eliminarService = new EliminarMensualidadService(_unitOfWork);
            EliminarMensualidadRequest request = new EliminarMensualidadRequest();
            request.IdMensualidad = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMensualidad", new { id = request.IdMensualidad }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpPut("PutEmail/{correo}")]
        public async Task<IActionResult> EnviarEmail([FromRoute] string correo, [FromBody] CrearMensualidadRequest mensualidad)
        {
            _eviarEmail = new EviarEmailService(_unitOfWork);
            var rta = _eviarEmail.EnviarEmail(mensualidad, correo);
            if (rta != null)
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMensualidad", new { id = mensualidad.id }, mensualidad);
            }
            return BadRequest(rta);

        }
    }
}
