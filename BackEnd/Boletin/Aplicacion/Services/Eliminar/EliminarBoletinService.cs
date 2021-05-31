using BackEnd.Base;
using BackEnd.Boletin.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Boletin.Aplicacion.Services.Eliminar
{
    
    public class EliminarBoletinService
    {
     readonly IUnitOfWork _unitOfWork;
        public EliminarBoletinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarBoletinResponse Ejecutar(EliminarBoletinRequest request)
        {
            Dominio.Boletin boletin = _unitOfWork.BoletinServiceRepository.FindFirstOrDefault(t => t.Id == request.IdBoletin);
            if (boletin == null)
            {
                return new EliminarBoletinResponse($"Boletin no existe");
            }
            else
            {
                _unitOfWork.BoletinServiceRepository.Delete(boletin);
                _unitOfWork.Commit();
                return new EliminarBoletinResponse($"Boletin Eliminado Exitosamente");
            }
        }
    }
   
}
