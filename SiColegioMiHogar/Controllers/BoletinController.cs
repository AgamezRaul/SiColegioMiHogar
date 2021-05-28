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
using BackEnd.Boletin.Aplicacion.Services.Crear;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletinController:ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearBoletinService _service;
        private UnitOfWork _unitOfWork;

        public BoletinController(MiHogarContext context)
        {
            this._context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        

    }
}
