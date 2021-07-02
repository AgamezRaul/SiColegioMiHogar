using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Dominio;
using BackEnd.Matricula.Aplicacion.Request;
using BackEnd.Matricula.Aplicacion.Service.Crear;
using BackEnd.Matricula.Aplicacion.Service.Eliminar;
using BackEnd.Matricula.Dominio;
using BackEnd.PreMatricula.Dominio;
using BackEnd.Usuario.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly CrearMatriculaService _crearService;
        private readonly EliminarMatriculaService _eliminarService;
        public MatriculaController(MiHogarContext context)
        {
            this._context = context;
            UnitOfWork _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearMatriculaService(_unitOfWork);
            _eliminarService = new EliminarMatriculaService(_unitOfWork);
        }

        [HttpGet]
        public object GetMatriculas()
        {
            var result = (from m in _context.Set<Matricula>()
                          join p in _context.Set<PreMatricula>()
                          on m.IdePreMatricula equals p.Id
                          join u in _context.Set<Usuario>()
                          on p.IdUsuario equals u.Id
                          join e in _context.Set<Estudiante>()
                          on u.Id equals e.IdUsuario
                          select new
                          {
                              IdMatricula = m.Id,
                              NomEstudiante = e.NomEstudiante,
                              FecMatricula = m.FecConfirmacion
                             
                          }).ToList();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatricula([FromRoute] int id)
        {
            Matricula matricula = await _context.Matricula.SingleOrDefaultAsync(t => t.Id == id);
            if (matricula == null)
                return NotFound();
            return Ok(matricula);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatricula( [FromBody] int idPreMatricula)
        {
            CrearMatriculaRequest request = new CrearMatriculaRequest
            {
                IdPreMatricula = idPreMatricula
               
            };
            var rta = _crearService.EjecutarCrearMatricula(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { IdPrematricula = request.IdPreMatricula }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula([FromRoute] int id)
        {
            EliminarMatriculaRequest request = new EliminarMatriculaRequest
            {
                Id = id
            };
            var rta = _eliminarService.EjecutarEliminarMatricula(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPrematricula", new { id = request.Id }, request);
            }
            return BadRequest(rta.Message);
        }
    }
}
