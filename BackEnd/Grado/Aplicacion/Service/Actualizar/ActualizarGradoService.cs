using BackEnd.Base;
using BackEnd.Grado.Aplicacion.Request;

namespace BackEnd.Grado.Aplicacion.Service.Actualizar
{
    public class ActualizarGradoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarGradoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarGradoResponse Ejecutar(ActualizarGradoRequest request)
        {
            Dominio.Grado grado = _unitOfWork.GradoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (grado == null)
            {
                return new ActualizarGradoResponse($"Grado no existe");
            }
            else
            {
                grado.Nombre = request.Nombre;

                _unitOfWork.GradoServiceRepository.Edit(grado);
                _unitOfWork.Commit();
                return new ActualizarGradoResponse($"Grado Actualizado Exitosamente");

            }
        }
    }
}
