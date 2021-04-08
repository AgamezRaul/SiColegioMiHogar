using BackEnd.Base;
using BackEnd.PreMatricula.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.PreMatricula.Aplicacion.Service.Actualizar
{
    public class ActualizarPreMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarPreMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarPreMatriculaResponse Ejecutar(ActualizarPreMatriculaRequest request)
        {
            Dominio.PreMatricula prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (prematricula == null)
            {
                return new ActualizarPreMatriculaResponse() { Message = $" PreMatricula no existe" };
            }
            else
            {
                prematricula.FecPrematricula = request.FecPrematricula;
                prematricula.Estado = request.Estado;
                     _unitOfWork.PreMatriculaServiceRepository.Edit(prematricula);
                _unitOfWork.Commit();
                return new ActualizarPreMatriculaResponse() { Message = $"PreMatricula Actualizada Exitosamente" };

            }
        }
    }
}
