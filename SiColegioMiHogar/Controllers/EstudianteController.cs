﻿using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Estudiante.Aplicacion.Services.Consultar;
using BackEnd.Estudiante.Dominio;
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
    public class EstudianteController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private ConsultarEstudanteService _service;
        //private ActualizarMateriaService _actualizarService;  genera errores
        private UnitOfWork _unitOfWork;

        public EstudianteController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet("[action]")]
        public IEnumerable<Estudiante> Estudiantes()
        {
            ConsultarEstudanteService servicio = new ConsultarEstudanteService(_unitOfWork);
            List<Estudiante> Lista = servicio.GetAll();
            return Lista;

        }
    }
}
