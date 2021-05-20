using BackEnd;
using BackEnd.Base;
using BackEnd.Usuario.Aplicacion.Request;
using BackEnd.Usuario.Aplicacion.Services.Actualizar;
using BackEnd.Usuario.Aplicacion.Services.Crear;
using BackEnd.Usuario.Aplicacion.Services.Eliminar;
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
    public class UsuarioController : ControllerBase
    {
        private readonly MiHogarContext _context;
        private CrearUsuarioService _service;
        private ActualizarUsuarioService _actualizarService;
        private EliminarUsuarioService _eliminarService;
        private UnitOfWork _unitOfWork;
        public UsuarioController(MiHogarContext context)
        {
            this._context = context; 
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpGet]
        public object GetUsuarios()
        {
            var result = (from u in _context.Set<Usuario>()
                          select new
                          {
                              id=u.Id,
                              correo= u.Correo,
                              tipoUsuario= u.TipoUsuario
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        [HttpGet("{correo}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string correo)
        {
            Usuario usuario = await _context.Usuario.SingleOrDefaultAsync(t => t.Correo == correo);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

      
        [HttpGet("GetUsuarioId/{id}")]
        public async Task<IActionResult> GetUsuarioId([FromRoute] int id)
        {
            Usuario usuario = await _context.Usuario.SingleOrDefaultAsync(t => t.Id == id);
            usuario.Password = usuario.Desencriptar(usuario.Password);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CrearUsuarioRequest usuario)
        {
            _service = new CrearUsuarioService(_unitOfWork);
            var rta = _service.Ejecutar(usuario);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { correo = usuario.Correo }, usuario);
            }
            return BadRequest(rta.Message);
        }


        [HttpDelete("{correo}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] string correo)
        {
            _eliminarService = new EliminarUsuarioService(_unitOfWork);
            EliminarUsuarioRequest request = new EliminarUsuarioRequest();
            request.Correo = correo;
            var rta = _eliminarService.Ejecutar(request);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { correo = request.Correo }, request);
            }
            return Ok(rta);
        }


       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromRoute] int id, [FromBody] ActualizarUsuarioRequest usuario)
        {
            _actualizarService = new ActualizarUsuarioService(_unitOfWork);
            var rta = _actualizarService.Ejecutar(usuario);
            if (rta.isOk())
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { correo = usuario.Correo }, usuario);
            }
            return BadRequest(rta.Message);
        }
    }
}
