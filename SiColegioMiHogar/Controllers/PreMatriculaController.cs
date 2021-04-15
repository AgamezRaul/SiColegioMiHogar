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
        private ActualizarPreMatriculaAllService _actualizarService;
        private EliminarPreMatriculaService _eliminarService;
        private UnitOfWork _unitOfWork;
        public PreMatriculaController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
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
                              where p.Id == id
                              select new
                              {
                                  /*e.CelEstudiante,
                                  e.Correo,
                                  e.DirResidencia,
                                  e.Eps,
                                  e.FecNacimiento,
                                  e.GradoEstudiante,
                                  e.Id,
                                  e.IdeEstudiante,
                                  e.IdUsuario,
                                  e.InsProcedencia,
                                  e.LugExpedicion,
                                  e.LugNacimiento,
                                  e.NomEstudiante,
                                  e.Sexo,
                                  e.TelEstudiante,
                                  e.TipoDocumento,
                                  e.TipSangre*/
                                  e
                              }).ToList();
            
            var responsables = (from p in _context.Set<PreMatricula>()
                                join u in _context.Set<Usuario>()
                                on p.IdUsuario equals u.Id
                                join r in _context.Set<Responsable>()
                                on u.Id equals r.IdUsuario
                                where p.Id == id
                                select new
                                {
                                    r
                                }).ToList();

            var preMatricula = (from p in _context.Set<PreMatricula>()
                                where p.Id == id
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
            _service = new CrearPreMatriculaService(_unitOfWork);
            var rta = _service.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPreMatricula", new { Id = request.id }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreMatricula([FromRoute] string id, [FromBody] ActualizarPreMatriculaAllRequest request)
        {
            _actualizarService = new ActualizarPreMatriculaAllService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPreMatricula", new { id = request.id }, request);
            }
            return BadRequest(rta.Message);
        }

        [HttpDelete("{id}")]
        public object DeletePreMatricula([FromRoute] int id)
        {
            _eliminarService = new EliminarPreMatriculaService(_unitOfWork);
            EliminarPreMatriculaRequest request = new EliminarPreMatriculaRequest();
            request.UsuarioId = id;
            var rta = _eliminarService.Ejecutar(request);
            return Ok(rta);
        }
    }
}
