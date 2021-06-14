using BackEnd;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;
using BackEnd.Boletin.Aplicacion.Services;

namespace SiColegioMiHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarPDFController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private readonly ConsultarPDFService _consultarPDFService;
       
        public GenerarPDFController(MiHogarContext context)
        {
            this._context = context;
            _consultarPDFService = new ConsultarPDFService(_context);
        }
        [HttpGet("PDFBoletin")]
        public IActionResult PDFBoletin()
        {
            var rta = _consultarPDFService.Ejecutar();
            return new ViewAsPdf("PDFBoletin") { Model=rta};
        }
    }
}
