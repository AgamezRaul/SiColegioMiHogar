using BackEnd.Base;
using BackEnd.Responsable.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

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
            Dominio.Responsable responsable = _unitOfWork.ResponsableServiceRepository.FindFirstOrDefault(t => t.IdUsuario == request.UsuarioId);
            if (responsable == null)
            {
                return new EliminarResponsableResponse() { Message = $"Responsable no existe" };
            }
            else
            {
                _unitOfWork.ResponsableServiceRepository.Delete(responsable);
                _unitOfWork.Commit();
                return new EliminarResponsableResponse() { Message = $"Responsable Eliminado Exitosamente" };
            }
        }
    }
}
