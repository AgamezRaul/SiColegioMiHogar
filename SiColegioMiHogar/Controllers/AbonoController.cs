using System.Linq;
using System.Threading.Tasks;
using BackEnd;
using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Abono.Aplicacion.Service.Actualizar;
using BackEnd.Abono.Aplicacion.Service.Anular;
using BackEnd.Abono.Aplicacion.Service.Crear;
using BackEnd.Abono.Dominio;
using BackEnd.Base;
using BackEnd.Estudiante.Dominio;
using BackEnd.Grado.Dominio;
using BackEnd.Matricula.Dominio;
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
        [HttpGet("GetAbonoMensualidad/{id}")]
        public object GetAbonoMensualidad([FromRoute] int id)
        {
            var result = (from a in _context.Set<Abono>()
                          join m in _context.Set<Mensualidad>()
                          on a.IdMensualidad equals m.Id
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
                          where m.Id == id
                          select new
                          {
                              Id = a.Id,
                              Estudiante = e.NomEstudiante,
                              FechaPago = a.FechaPago,
                              ValorAbono = a.ValorAbono,
                              EstadoAbono = a.EstadoAbono,
                              ValorMatricula = vm.PrecioMensualidad,
                              Deuda = m.Deuda
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbono([FromRoute] int id)
        {
            Abono abono = await _context.Abono.SingleOrDefaultAsync(t => t.Id == id);
            if (abono == null)
                return NotFound();
            return Ok(abono);
        }
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
        public async Task<IActionResult> PutAnular([FromRoute] int id, [FromBody] AnularAbonoRequest abono)
        {
            _anularService = new AnularAbonoService(_unitOfWork);
            var rta = _anularService.Ejecutar(abono);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAbono", new { id = abono.id }, abono);
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
