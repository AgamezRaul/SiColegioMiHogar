using BackEnd.Base;
using BackEnd.RelacionUR.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.RelacionUR.Aplicacion.Service.Actualizar
{
    public class ActualizarRelacionURService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarRelacionURService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarRelacionURResponse Ejecutar(ActualizarRelacionURRequest request)
        {
            Dominio.RelacionUR relacionUR = _unitOfWork.RelacionURServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (relacionUR == null)
            {
                return new ActualizarRelacionURResponse() { Message = $"Relacion Usuario Responsable no existe" };
            }
            else
            {
                relacionUR.IdResponsable = request.IdResponsable;
                relacionUR.IdUsuario = request.IdUsuario;
                _unitOfWork.RelacionURServiceRepository.Edit(relacionUR);
                _unitOfWork.Commit();
                return new ActualizarRelacionURResponse() { Message = $"Relacion Usuario Responsable Actualizada Exitosamente" };

            }
        }
    }
}
