using BackEnd.Base;
using BackEnd.Usuario.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Aplicacion.Services
{
    public class LoginService
    {
        readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public LoginResponse Login(LoginRequest request)
        {

            var usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.Correo == request.Correo);
            if (usuario == null)
            {
                return new LoginResponse() { Message = $"No existe ese usuario" };
            }
            if (usuario.Desencriptar(usuario.Password) == request.Password)
            {
                return new LoginResponse()
                {
                    Id = usuario.Id,
                    Message = $"Usuario y Contraseña Correctos",
                    TipoUsuario = usuario.TipoUsuario,
                };
            }
            return new LoginResponse() { Message = $"Contraseña Incorrecta" };

        }
    }
}
