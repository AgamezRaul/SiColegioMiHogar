using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Abono.Aplicacion.Service.Anular
{
    public class AnularAbonoService
    {
        readonly IUnitOfWork _unitOfWork;
        public AnularAbonoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AnularAbonoResponse Ejecutar(AnularAbonoRequest request)
        {
            Dominio.Abono abono = _unitOfWork.AbonoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (abono == null)
            {
                return new AnularAbonoResponse($"Abono no existe");
            }
            else
            {
                abono.EstadoAbono = request.EstadoAbono;
                _unitOfWork.AbonoServiceRepository.Edit(abono);
                _unitOfWork.Commit();
                return new AnularAbonoResponse($"Abono Anulado Exitosamente");

            }
        }
    }
}
