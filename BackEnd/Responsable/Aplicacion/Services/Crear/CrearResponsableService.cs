using BackEnd.Base;
using BackEnd.Responsable.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Responsable.Aplicacion.Services.Crear
{
  public  class CrearResponsableService
    {

        readonly IUnitOfWork _unitOfWork;
        public CrearResponsableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearResponsableResponse Ejecutar(List<CrearResponsableRequest> responsables)
        {
            foreach (var request in responsables)
            {
                var responsable = _unitOfWork.ResponsableServiceRepository.FindFirstOrDefault(t => t.IdeResponsable == request.IdeResponsable);
                if (responsable != null)
                {
                    return new CrearResponsableResponse($"Responsable ya existe");
                }
                Dominio.Responsable newResponsable = new Dominio.Responsable(request.IdeResponsable, request.NomResponsable, request.FecNacimiento, request.LugNacimiento,
                    request.LugExpedicion, request.TipDocumento, request.CelResponsable, request.ProfResponsable, request.OcuResponsable, request.EntResponsable, request.CelEmpresa,
                    request.TipoResponsable, request.Correo, request.Acudiente, request.IdUsuario);
                _unitOfWork.ResponsableServiceRepository.Add(newResponsable);
            }
            return new CrearResponsableResponse($"Responsables Creados Exitosamente");
        }
    }
}
