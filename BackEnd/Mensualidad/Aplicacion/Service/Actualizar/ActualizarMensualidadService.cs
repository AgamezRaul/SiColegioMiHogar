using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Mensualidad.Aplicacion.Service.Actualizar
{
   public class ActualizarMensualidadService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarMensualidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarMensualidadResponse Ejecutar(ActualizarMensualidadRequest request)
        {
            Dominio.Mensualidad mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (mensualidad == null)
            {
                return new ActualizarMensualidadResponse() { Message = $"Mensualidad no existe" };
            }
            else
            {
                //mensualidad.Mes = request.Mes;
                mensualidad.DiaPago = request.DiaPago;
                mensualidad.FechaPago = request.FechaPago;
                mensualidad.ValorMensualidad = request.ValorMensualidad;
                mensualidad.DescuentoMensualidad = request.DescuentoMensualidad;
                mensualidad.Abono = request.Abono;
                mensualidad.Deuda = request.Deuda;
                mensualidad.Estado = request.Estado;
                mensualidad.TotalMensualidad = request.TotalMensualidad;
                
                _unitOfWork.MensualidadServiceRepository.Edit(mensualidad);
                _unitOfWork.Commit();
                return new ActualizarMensualidadResponse() { Message = $"Mensualidad Actualizada Exitosamente" };

            }
        }
    }
}
