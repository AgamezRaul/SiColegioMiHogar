using BackEnd;
using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using BackEnd.Nota.Aplicacion.Services;
using BackEnd.Nota.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Actividad;
using BackEnd.Materia.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Curso.Dominio;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly CrearNotaService _service;
        private readonly UnitOfWork _unitOfWork;

        public NotaController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
            _service = new CrearNotaService(_unitOfWork);
        }

        [HttpGet]
        public IEnumerable<Nota> GetNotas()
        {
            return _context.Nota;
        }

        [HttpGet("GetEstudiantes/{idMateria}")]
        public Object GetEstudiantes()
        {
            var result = (from a in _context.Set<Actividad>()
                          join m in _context.Set<Materias>()
                          on a.IdMateria equals m.Id
                          join c in _context.Set<Curso>()
                          on m.IdCurso equals c.Id
                          select new
                          {
                          }).ToList();
            return result;
        }


        [HttpPost]
        public async Task<IActionResult> CreateNota([FromBody] List<CrearNotaRequest> nota)
        {            
            var rta = _service.Ejecutar(nota);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetNota", nota);
            }
            return BadRequest(rta.Message);
        }

        
        [HttpGet("[action]")]
        public Nota GetNota(int id)
        {
            ConsultarNotaService service = new ConsultarNotaService(_unitOfWork);
            return service.GetNota(id);
        }

        [HttpDelete("[action]")]
        public ActionResult<EliminarNotaResponse> DeleteNota(int id)
        {
            EliminarNotaService service = new EliminarNotaService(_unitOfWork);
            EliminarNotaResponse response = service.EjecutarEliminarNota(id);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public ActionResult<ActualizarResponse> ActualizarNota([FromBody] CrearNotaRequest request)
        {
            ActualizarNotaService service = new ActualizarNotaService(_unitOfWork);
            ActualizarResponse response = service.ActualizarNota(request);
            return Ok(response);
        }
    }
}
