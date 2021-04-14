using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Estudiante.Aplicacion.Services.Eliminar
{
    public class EliminarEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarEstudianteResponse Ejecutar(EliminarEstudianteRequest request)
        {
            Dominio.Estudiante estudiante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.IdUsuario == request.IdUsuario);
            if (estudiante == null)
            {
                return new EliminarEstudianteResponse() { Message = $"Estudiante no existe" };
            }
            else
            {
                _unitOfWork.EstudianteServiceRepository.Delete(estudiante);
                _unitOfWork.Commit();
                return new EliminarEstudianteResponse() { Message = $"Estudiante Eliminado Exitosamente" };
            }
        }
    }
}
