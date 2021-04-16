using BackEnd;
using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using BackEnd.Nota.Aplicacion.Services;
using BackEnd.Nota.Dominio.Entidades;
using BackEnd.Nota.Dominio;
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
    public class NotaController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearNotaService _service;
        //private ActualizarMateriaService _actualizarService;  genera errores
        private UnitOfWork _unitOfWork;

        public NotaController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        public NotaResponse notaResponse;

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNota([FromBody] NotaRequest nota)
        {
            notaResponse = new NotaResponse();

            _service = new CrearNotaService(_unitOfWork);

            var rta = _service.Ejecutar(nota);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetNota", new { nota = nota.IdEstudiante }, nota);
            }
            return BadRequest(rta.Message);
        }

        [HttpGet("[action]")]
        public IEnumerable<NotaResponseConsult> Notas()
        {
            ConsultarNotaService servicio = new ConsultarNotaService(_unitOfWork);
            List<NotaResponseConsult> Lista = servicio.GetAll();
            return Lista;

        }
    }
}
