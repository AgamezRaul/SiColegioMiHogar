﻿using BackEnd;
using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;
using BackEnd.Contrato.Aplicacion.Service;
using BackEnd.Contrato.Dominio;
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
    public class ContratoController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly CrearContratoService _crearService;
        private ActualizarContratoService _actualizarService;
        private UnitOfWork _unitOfWork;
        public ContratoController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
            _crearService = new CrearContratoService(_unitOfWork);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrematricula([FromBody] CrearContratoRequest request)
        {
            var rta = _crearService.EjecutarCrearContrato(request);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPreMatricula", new { Id = request.IdDocente }, request);
            }
            return BadRequest(rta.Message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato([FromRoute] int id, [FromBody] ActualizarContratoRequest contrato)
        {
            _actualizarService = new ActualizarContratoService(_unitOfWork);
            var rta = _actualizarService.EjecutarActualizarContrato(contrato);
            if (rta.IsOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetContrato", new { id = contrato.IdDocente }, contrato);
            }
            return BadRequest(rta.Message);
        }
        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContrato([FromRoute] int id)
        {
            Contrato contrato = await _context.Contrato.SingleOrDefaultAsync(t => t.IdDocente == id);
            if (contrato == null)
                return NotFound();
            return Ok(contrato);
        }
        */

        [HttpGet("[action]")]
        public Contrato GetContrato(int id)
        {
            ConsultarContratoService service = new ConsultarContratoService(_unitOfWork);
            return service.GetContrato(id);
        }
    }
}
