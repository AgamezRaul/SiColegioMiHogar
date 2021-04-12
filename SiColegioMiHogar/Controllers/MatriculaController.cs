using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Dominio;
using BackEnd.Matricula.Aplicacion.Request;
using BackEnd.Matricula.Aplicacion.Service.Crear;
using BackEnd.Matricula.Dominio;
using BackEnd.PreMatricula.Dominio;
using BackEnd.Usuario.Dominio;
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
    public class MatriculaController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearMatriculaService _service;
        private CrearMatriculaRequest request;
        private UnitOfWork _unitOfWork;
        public MatriculaController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
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
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
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
        public async Task<IActionResult> CreateMatricula([FromBody] int idPreMatricula)
        {
            _service = new CrearMatriculaService(_unitOfWork);
            request = new CrearMatriculaRequest();
            request.IdPreMatricula = idPreMatricula;
            var rta = _service.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { IdPrematricula = request.IdPreMatricula }, request);
            }
            return BadRequest(rta.Message);
        }
    }
}
