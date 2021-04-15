using BackEnd.Base;
using BackEnd.Usuario.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Usuario.Aplicacion.Services.Crear
{
    public class CrearUsuarioService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearUsuarioResponse Ejecutar(CrearUsuarioRequest request)
        {
            var usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.Correo == request.Correo);
            if (usuario == null)
            {
                Dominio.Usuario newUsuario = new Dominio.Usuario(request.Correo,request.Password, request.TipoUsuario);

                if (newUsuario.Password.Length < 6)
                {
                    IReadOnlyList<string> errors = newUsuario.CanCrear(newUsuario);

                    if (errors.Any())
                    {
                        string listaErrors = "Errores:";
                        foreach (var item in errors)
                        {
                            listaErrors += item.ToString();
                        }
                        return new CrearUsuarioResponse() { Message = listaErrors };
                    }
                    else
                    {
                        _unitOfWork.UsuarioServiceRepository.Add(newUsuario);
                        _unitOfWork.Commit();
                        return new CrearUsuarioResponse() { Message = $"Usuario Creado Exitosamente" };
                    }
                }
                else
                {
                    return new CrearUsuarioResponse() { Message = $"La contraseña debe de contener mas de 6 digitos" };
                }  
            }
            else
            {
                return new CrearUsuarioResponse() { Message = $"Usuario ya existe" };
            }
        }
    }
}
