using BackEnd.Base;
using BackEnd.Responsable.Aplicacion.Request;

namespace BackEnd.Responsable.Aplicacion.Services.Eliminar
{
    public class EliminarResponsableService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarResponsableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarResponsableResponse Ejecutar(EliminarResponsableRequest request)
        {
            for (int i = 1; i <= 3; i++)
            {
                Dominio.Responsable responsable = _unitOfWork.ResponsableServiceRepository.FindFirstOrDefault(t => t.IdUsuario == request.UsuarioId);
                if (responsable == null)
                {
                    return new EliminarResponsableResponse($"Responsable no existe");
                }
                _unitOfWork.ResponsableServiceRepository.Delete(responsable);
            }
            return new EliminarResponsableResponse($"Responsables Eliminados Exitosamente");
        }
    }
}
