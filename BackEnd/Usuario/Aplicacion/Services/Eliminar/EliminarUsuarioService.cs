using BackEnd.Base;
using BackEnd.Usuario.Aplicacion.Request;

namespace BackEnd.Usuario.Aplicacion.Services.Eliminar
{
    public class EliminarUsuarioService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarUsuarioResponse Ejecutar(EliminarUsuarioRequest request)
        {
            Dominio.Usuario usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.Correo == request.Correo);
            if (usuario == null)
            {
                return new EliminarUsuarioResponse() { Message = $"Usuario no existe" };
            }
            else
            {
                _unitOfWork.UsuarioServiceRepository.Delete(usuario);
                _unitOfWork.Commit();
                return new EliminarUsuarioResponse() { Message = $"Usuario eliminado exitosamente" };
            }
        }
    }
}
