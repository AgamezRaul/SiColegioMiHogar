using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Mensualidad.Aplicacion.Service.Eliminar
{
   public  class EliminarMensualidadService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarMensualidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarMensualidadResponse Ejecutar(EliminarMensualidadRequest request)
        {
            Dominio.Mensualidad mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.IdMensualidad);
            if (mensualidad == null)
            {
                return new EliminarMensualidadResponse() { Message = $"Mensualidad no existe" };
            }
            else
            {
                _unitOfWork.MensualidadServiceRepository.Delete(mensualidad);
                _unitOfWork.Commit();
                return new EliminarMensualidadResponse() { Message = $"Mensualidad Eliminada Exitosamente" };
            }
        }
    }
}
