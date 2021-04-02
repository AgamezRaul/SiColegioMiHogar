using BackEnd.Base;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.PreMatricula.Aplicacion.Service.Crear
{
   public  class CrearPreMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearPreMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearPreMatriculaResponse Ejecutar(CrearPreMatriculaRequest request)
        {
            var prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            
            if (prematricula == null)
            {
                Dominio.PreMatricula newPreMatricula = new Dominio.PreMatricula(request.FecPrematricula, request.IdResponsable, request.Estado);
                
                IReadOnlyList<string> errors = newPreMatricula.CanCrear(newPreMatricula);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearPreMatriculaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.PreMatriculaServiceRepository.Add(newPreMatricula);
                    _unitOfWork.Commit();
                    return new CrearPreMatriculaResponse() { Message = $"PreMatricula Creada Exitosamente" };
                }
            }
            else
            {
                return new CrearPreMatriculaResponse() { Message = $"PreMatricula ya existe" };
            }
        }
    }
}
