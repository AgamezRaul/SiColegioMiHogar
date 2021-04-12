using BackEnd.Base;
using BackEnd.Matricula.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Matricula.Aplicacion.Service.Actualizar
{
    public class ActualizarMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarMatriculaResponse Ejecutar(ActualizarMatriculaRequest request)
        {
            Dominio.Matricula matricula = _unitOfWork.MatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (matricula == null)
            {
                return new ActualizarMatriculaResponse() { Message = $"Matricula no existe" };
            }
            else
            {
                matricula.IdePreMatricula = request.IdPreMatricula;
                _unitOfWork.MatriculaServiceRepository.Edit(matricula);
                _unitOfWork.Commit();
                return new ActualizarMatriculaResponse() { Message = $"Matricula Actualizada Exitosamente" };

            }
        }
    }
}
