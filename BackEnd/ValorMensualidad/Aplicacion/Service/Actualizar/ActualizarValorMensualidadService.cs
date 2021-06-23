using BackEnd.Base;
using BackEnd.ValorMensualidad.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.ValorMensualidad.Aplicacion.Service.Actualizar
{
  public  class ActualizarValorMensualidadService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarValorMensualidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarValorMensualidadResponse Ejecutar(ActualizarValorMensualidadRequest request)
        {
            Dominio.ValorMensualidad valorMensualidad = _unitOfWork.ValorMensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (valorMensualidad == null)
            {
                return new ActualizarValorMensualidadResponse($"Valor Mensualidad no existe");
            }
            else
            {
                valorMensualidad.Fecha = request.Fecha;
                valorMensualidad.Año = request.Año;
                valorMensualidad.PrecioMensualidad = request.PrecioMensualidad;
                _unitOfWork.ValorMensualidadServiceRepository.Edit(valorMensualidad);
                _unitOfWork.Commit();
                return new ActualizarValorMensualidadResponse($"Valor Mensualidad Actualizada Exitosamente");

            }
        }
    }
}
