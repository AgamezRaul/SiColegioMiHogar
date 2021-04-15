using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Estudiante.Aplicacion.Services.Eliminar;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Services.Eliminar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.PreMatricula.Aplicacion.Service.Eliminar
{
    public class EliminarPreMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarEstudianteService estudianteService;
        public EliminarResponsableService responsableService;
        public EliminarPreMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            estudianteService = new EliminarEstudianteService(_unitOfWork);
            responsableService = new EliminarResponsableService(_unitOfWork);
        }
        public EliminarPreMatriculaResponse Ejecutar(EliminarPreMatriculaRequest request)
        {
            Dominio.PreMatricula prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.IdUsuario == request.UsuarioId);
            EliminarEstudianteRequest estudianteRequest = new EliminarEstudianteRequest();
            estudianteRequest.IdUsuario = request.UsuarioId;
            EliminarResponsableRequest responsableRequest = new EliminarResponsableRequest();
            responsableRequest.UsuarioId = request.UsuarioId;
            var respuestaE = estudianteService.Ejecutar(estudianteRequest);
            for (int i = 1; i <= 3; i++)
            {
                var respuesta = responsableService.Ejecutar(responsableRequest);
            }
            if (prematricula == null)
            {
                return new EliminarPreMatriculaResponse() { Message = $"PreMatricula no existe" };
            }
            else
            {
                _unitOfWork.PreMatriculaServiceRepository.Delete(prematricula);
                _unitOfWork.Commit();
                return new EliminarPreMatriculaResponse() { Message = $"PreMatricula Eliminado Exitosamente" };
            }
        }
    }
}
