using BackEnd.Base;
using BackEnd.Grado.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Grado.Aplicacion.Service.Eliminar
{
   public class EliminarGradoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarGradoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarGradoResponse Ejecutar(EliminarGradoRequest request)
        {
            Dominio.Grado grado = _unitOfWork.GradoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (grado == null)
            {
                return new EliminarGradoResponse($"Grado no existe");
            }
            else
            {
                _unitOfWork.GradoServiceRepository.Delete(grado);
                _unitOfWork.Commit();
                return new EliminarGradoResponse($"Grado Eliminado Exitosamente");
            }
        }
    }
}
