using BackEnd;
using BackEnd.Base;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Service.Crear;
using BackEnd.PreMatricula.Dominio;
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
    public class PreMatriculaController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearPreMatriculaService _service;
        private UnitOfWork _unitOfWork;
        public PreMatriculaController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public IEnumerable<PreMatricula> GetPreMatriculas()
        {
            return _context.PreMatricula;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreMatricula([FromRoute] int id)
        {
            PreMatricula preMatricula = await _context.PreMatricula.SingleOrDefaultAsync(t => t.Id == id);
            if (preMatricula == null)
                return NotFound();
            return Ok(preMatricula);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CrearPreMatriculaRequest request)
        {
            _service = new CrearPreMatriculaService(_unitOfWork);
            var rta = _service.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPreMatricula", new { Id = request.id }, request);
            }
            return BadRequest(rta.Message);
        }
    }
}
