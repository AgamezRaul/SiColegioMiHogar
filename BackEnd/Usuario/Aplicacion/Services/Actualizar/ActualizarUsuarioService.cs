using BackEnd.Base;
using BackEnd.Usuario.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Aplicacion.Services.Actualizar
{
   public class ActualizarUsuarioService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarUsuarioResponse Ejecutar(ActualizarUsuarioRequest request)
        {
            Dominio.Usuario usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (usuario == null)
            {
                return new ActualizarUsuarioResponse($"Usuario no existe") ;     
            }
            else
            {
                usuario.Password = usuario.Encriptar(request.Password);
                usuario.TipoUsuario = request.TipoUsuario;
                _unitOfWork.UsuarioServiceRepository.Edit(usuario);
                _unitOfWork.Commit();
                return new ActualizarUsuarioResponse($"Usuario Actualizado Exitosamente");

            }
        }
    }
}


