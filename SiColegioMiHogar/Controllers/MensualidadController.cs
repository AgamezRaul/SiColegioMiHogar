﻿using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Dominio;
using BackEnd.Matricula.Dominio;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service.Actualizar;
using BackEnd.Mensualidad.Aplicacion.Service.Crear;
using BackEnd.Mensualidad.Dominio;
using BackEnd.PreMatricula.Dominio;
using BackEnd.Usuario.Dominio;
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
    public class MensualidadController : Controller
    {
        private readonly MiHogarContext _context;
        private CrearMensualidadService _service;
        private ActualizarMensualidadService _actualizarService;
        private UnitOfWork _unitOfWork;
        public MensualidadController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public object GetMensualidades()
        {
            var result = (from m in _context.Set<Mensualidad>()
                          join ma in _context.Set<Matricula>()
                          on m.IdMatricula equals ma.Id
                          join p in _context.Set<PreMatricula>()
                          on ma.IdePreMatricula equals p.Id
                          join u in _context.Set<Usuario>()
                          on p.IdUsuario equals u.Id
                          join e in _context.Set<Estudiante>()
                          on u.Id equals e.IdUsuario
                          select new
                          {
                              Estudiante = e.NomEstudiante,
                              Mes= m.Mes,
                              DiaPago= m.DiaPago,
                              FechaPago=m.FechaPago,
                              ValorMensualidad=m.ValorMensualidad,
                              DescuentoMensualidad=m.DescuentoMensualidad,
                              Abono=m.Abono,
                              Deuda=m.Deuda,
                              Estado=m.Estado,
                              TotalMensualidad =m.TotalMensualidad
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMensualidad([FromRoute] int id)
        {
            Mensualidad mensualidad = await _context.Mensualidad.SingleOrDefaultAsync(t => t.Id == id);
            if (mensualidad == null)
                return NotFound();
            return Ok(mensualidad);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMensualidad([FromBody] CrearMensualidadRequest mensualidad)
        {
            _service = new CrearMensualidadService(_unitOfWork);
            var rta = _service.Ejecutar(mensualidad);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                //busaca en la base de datos para guardar
                return CreatedAtAction("GetMensualidad", new { id = mensualidad.id }, mensualidad);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensualidad([FromRoute] int id, [FromBody] ActualizarMensualidadRequest mensualidad)
        {
            _actualizarService = new ActualizarMensualidadService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(mensualidad);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMensualidad", new { mes = mensualidad.Mes }, mensualidad);
            }
            return BadRequest(rta.Message);
        }
        
      
       
        /* public IActionResult Index()
         {
             return View();
         }*/
    }
}
