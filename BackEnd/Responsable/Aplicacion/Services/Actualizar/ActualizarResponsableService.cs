using BackEnd.Base;
using BackEnd.Responsable.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Responsable.Aplicacion.Services.Actualizar
{
   public  class ActualizarResponsableService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarResponsableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarResponsableResponse Ejecutar(ActualizarResponsableRequest request)
        {
            Dominio.Responsable responsable = _unitOfWork.ResponsableServiceRepository.FindFirstOrDefault(t => t.IdeResponsable == request.IdeResponsable);
            if (responsable == null)
            {
                return new ActualizarResponsableResponse() { Message = $"Responsable no existe" };
            }
            else
            {
               responsable.IdeResponsable=request.IdeResponsable;
               responsable.NomResponsable =request.NomResponsable; 
               responsable.FecNacimiento=request.FecNacimiento;
               responsable.LugNacimiento =request.LugNacimiento;
               responsable.LugExpedicion =request.LugExpedicion; 
               responsable.TipDocumento =request.TipDocumento;
               responsable.CelResponsable =request.CelResponsable;
               responsable.ProfResponsable=request.ProfResponsable; 
               responsable.OcuResponsable=request.OcuResponsable;
               responsable.EntResponsable =request.EntResponsable;
               responsable.CelEmpresa =request.CelEmpresa;
               responsable.TipoResponsable =request.TipoResponsable;
               responsable.Correo=request.Correo;
               responsable.Acudiente =request.Acudiente;

                _unitOfWork.ResponsableServiceRepository.Edit(responsable);
                _unitOfWork.Commit();
                return new ActualizarResponsableResponse() { Message = $"Responsable Actualizado Exitosamente" };

            }
        }
    }
}
