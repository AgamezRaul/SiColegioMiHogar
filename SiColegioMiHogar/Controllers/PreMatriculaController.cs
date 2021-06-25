using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Dominio;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Service.Actualizar;
using BackEnd.PreMatricula.Aplicacion.Service.Crear;
using BackEnd.PreMatricula.Aplicacion.Service.Eliminar;
using BackEnd.PreMatricula.Dominio;
using BackEnd.Responsable.Dominio;
using BackEnd.Usuario.Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreMatriculaController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly CrearPreMatriculaService _service;
        private readonly ActualizarPreMatriculaAllService _actualizarService;
        private readonly EliminarPreMatriculaService _eliminarService;
        public PreMatriculaController(MiHogarContext context)
        {
            this._context = context;
            UnitOfWork _unitOfWork = new UnitOfWork(_context);
            _service = new CrearPreMatriculaService(_unitOfWork);
            _actualizarService = new ActualizarPreMatriculaAllService(_unitOfWork);
            _eliminarService = new EliminarPreMatriculaService(_unitOfWork);
        }


        [HttpGet]
        public object tablaPrematricula()
        {
            var result = (from p in _context.Set<PreMatricula>()
                          join e in _context.Set<Estudiante>()
                          on p.IdUsuario equals e.IdUsuario
                          select new
                          {
                              IdUsuario = p.IdUsuario,
                              IdPrematricula = p.Id,
                              NomEstudiante = e.NomEstudiante,
                              FecPrematricula = p.FecPrematricula,
                              Estado = p.Estado
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{id}")]
        public object GetPreMatricula([FromRoute] int id)
        {
            var estudiante = (from p in _context.Set<PreMatricula>()
                              join u in _context.Set<Usuario>()
                              on p.IdUsuario equals u.Id
                              join e in _context.Set<Estudiante>()
                              on u.Id equals e.IdUsuario
                              where u.Id == id
                              select new
                              {
                                  e
                              }).ToList();

            var responsables = (from p in _context.Set<PreMatricula>()
                                join u in _context.Set<Usuario>()
                                on p.IdUsuario equals u.Id
                                join r in _context.Set<Responsable>()
                                on u.Id equals r.IdUsuario
                                where u.Id == id
                                select new
                                {
                                    r
                                }).ToList();

            var preMatricula = (from p in _context.Set<PreMatricula>()
                                join u in _context.Set<Usuario>()
                                on p.IdUsuario equals u.Id
                                where u.Id == id
                                select new
                                {
                                    IdPrematricula = p.Id,
                                    p.IdUsuario,
                                    estudiante,
                                    responsables
                                }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(preMatricula, Newtonsoft.Json.Formatting.Indented);
            if (preMatricula == null)
                return NotFound();
            return Ok(preMatricula);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrematricula([FromBody] CrearPreMatriculaRequest request)
        {
            var rta = _service.EjecutarCrearPreMatricula(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPreMatricula", new { Id = request.id }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreMatricula([FromRoute] int id, [FromBody] ActualizarPreMatriculaAllRequest request)
        {
            var rta = _actualizarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPreMatricula", new { id = request.id }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreMatricula([FromRoute] int id)
        {
            EliminarPreMatriculaRequest request = new EliminarPreMatriculaRequest
            {
                UsuarioId = id
            };
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPrematricula", new { id = request.UsuarioId }, request);
            }
            return BadRequest(rta.Message);
        }
    }
}
