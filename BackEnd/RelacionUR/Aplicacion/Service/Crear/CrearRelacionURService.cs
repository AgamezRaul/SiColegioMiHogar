using BackEnd.Base;
using BackEnd.RelacionUR.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.RelacionUR.Aplicacion.Service.Crear
{
    public class CrearRelacionURService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearRelacionURService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearRelacionURResponse Ejecutar(CrearRelacionURRequest request)
               
        {
            var relacionUR = _unitOfWork.RelacionURServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (relacionUR == null)
            {
                Dominio.RelacionUR newRelacionUR = new Dominio.RelacionUR(request.IdResponsable, request.IdUsuario);

                IReadOnlyList<string> errors = newRelacionUR.CanCrear(newRelacionUR);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearRelacionURResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.RelacionURServiceRepository.Add(newRelacionUR);
                    _unitOfWork.Commit();
                    return new CrearRelacionURResponse() { Message = $"Relacion Responsable Usuario Creada Exitosamente" };
                }
            }
            else
            {
                return new CrearRelacionURResponse() { Message = $"Relacion Responsable Usuario ya existe" };
            }
        }
    }
}
