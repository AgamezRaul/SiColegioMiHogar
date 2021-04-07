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
        public CrearResponsableResponse Ejecutar(CrearResponsableRequest request)
        {
            var responsable = _unitOfWork.ResponsableServiceRepository.FindFirstOrDefault(t => t.IdeResponsable == request.IdeResponsable);
            if (responsable == null)
            {
                Dominio.Responsable newResponsable = new Dominio.Responsable(request.IdeResponsable, request.NomResponsable, request.FecNacimiento, request.LugNacimiento,
                    request.LugExpedicion, request.TipDocumento, request.CelResponsable, request.ProfResponsable, request.OcuResponsable, request.EntResponsable, request.CelEmpresa,
                    request.TipoResponsable, request.Correo, request.Acudiente, request.IdEstudiante, request.IdPrematricula);

                IReadOnlyList<string> errors = newResponsable.CanCrear(newResponsable);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearResponsableResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.ResponsableServiceRepository.Add(newResponsable);
                    _unitOfWork.Commit();
                    return new CrearResponsableResponse() { Message = $"Responsable Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearResponsableResponse() { Message = $"Responsable ya existe" };
            }
        }
    }
}
