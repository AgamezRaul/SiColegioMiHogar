using BackEnd;
using BackEnd.Base;
using BackEnd.Periodo.Dominio;
using BackEnd.Estudiante.Dominio;
using BackEnd.Boletin.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Boletin.Aplicacion.Request;
using BackEnd.Boletin.Aplicacion.Services.Crear;
using BackEnd.Boletin.Aplicacion.Services.Eliminar;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletinController: Controller
    {
        private readonly MiHogarContext _context;
        private CrearBoletinService _service;
        private UnitOfWork _unitOfWork;
        private EliminarBoletinService _eliminarService;
        public BoletinController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
            
        }

        [HttpGet]
        public Object GetBoletines()
        {
            var result = (from b in _context.Set<Boletin>()
                          join e in _context.Set<Estudiante>()
                          on b.IdEstudiante equals e.Id
                          join p in _context.Set<Periodo>()
                          on b.IdPeriodo equals  p.Id
                          select new
                          {
                              b.Id,
                              b.FechaGeneracion,
                              b.IdPeriodo,
                              e.NomEstudiante,
                              e.IdeEstudiante,
                              e.GradoEstudiante,
                              p.NombrePeriodo,
                              p.NumeroPeriodo
                              
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoletin([FromRoute] int id)
        {
            Boletin boletin = await _context.Boletin.SingleOrDefaultAsync(t => t.Id == id);
            if (boletin == null)
            {
                return NotFound();
            }
            return Ok(boletin);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoletin([FromRoute] int id)
        {
            _eliminarService = new EliminarBoletinService(_unitOfWork);
            EliminarBoletinRequest request = new EliminarBoletinRequest();
            request.IdBoletin = id;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBoletin", new { id = request.IdBoletin }, request);
            }
            return BadRequest(rta.Message);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBoletin([FromBody] CrearBoletinRequest boletin)
        {
            _service = new CrearBoletinService(_unitOfWork);
            var rta = _service.Ejecutar(boletin);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBoletin", new { id = boletin.id }, boletin);
            }
            return BadRequest(rta.Message);
        }
    }
}
