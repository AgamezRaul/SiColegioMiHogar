using BackEnd;
using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using BackEnd.Nota.Aplicacion.Services;
using BackEnd.Nota.Dominio.Entidades;
using BackEnd.Nota.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearNotaService _service;
        private UnitOfWork _unitOfWork;

        public NotaController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<Nota> GetNotas()
        {
            return _context.Nota;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNota([FromBody] CrearNotaRequest nota)
        {
            _service = new CrearNotaService(_unitOfWork);
            var rta = _service.Ejecutar(nota);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { Descripcion = nota.Descripcion }, nota);
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
        public ActionResult<EliminarResponse> DeleteNota(int id)
        {
            EliminarNotaService service = new EliminarNotaService(_unitOfWork);
            EliminarResponse response = service.DeleteNota(id);
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
