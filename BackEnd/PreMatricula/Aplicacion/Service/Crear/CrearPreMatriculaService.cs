using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Responsable.Aplicacion.Services.Crear;
using BackEnd.Estudiante.Aplicacion.Services.Crear;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Request;

namespace BackEnd.PreMatricula.Aplicacion.Service.Crear
{
   public  class CrearPreMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearEstudianteService estudianteService;
        public CrearResponsableService responsableService;
        public CrearEstudianteRequest _estudianteRequest;
        public CrearResponsableRequest _responsableRequest;

        public CrearPreMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            estudianteService = new CrearEstudianteService(_unitOfWork);
            responsableService = new CrearResponsableService(_unitOfWork);

        }
        public CrearPreMatriculaResponse Ejecutar(CrearPreMatriculaRequest request)
        {
            var prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (prematricula == null)
            {
                Dominio.PreMatricula newPreMatricula = new Dominio.PreMatricula(request.FecPrematricula, request.IdUsuario, request.Estado);

                var respuestaE = estudianteService.Ejecutar(request.Estudiante);
                foreach (var responsable in request.Responsables)
                {
                    var respuesta = responsableService.Ejecutar(responsable);
                }
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
