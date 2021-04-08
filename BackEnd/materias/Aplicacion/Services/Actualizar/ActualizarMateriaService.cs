using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Base;
using BackEnd.materias.Aplicacion.Request;

namespace BackEnd.materias.Aplicacion.Services.Actualizar
{
    class ActualizarMateriaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ActualizarMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarMateriaResponse Ejecutar(ActualizarMateriaRequest request)
        {
            Dominio.Materia materia = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.IdeEstudiante == request.IdeEstudiante);
            if (materia == null)
            {
                return new ActualizarMateriaResponse() { Message = $"La materia no existe" };
            }
            else
            {/*
                Materia.IdeEstudiante = request.IdeEstudiante;
                Materia.NomEstudiante = request.NomEstudiante;
                Materia.FecNacimiento = request.FecNacimiento;
                Materia.LugNacimiento = request.LugNacimiento;

                _unitOfWork.EstudianteServiceRepository.Edit(estudiante);
                _unitOfWork.Commit();
                return new ActualizarEstudianteResponse() { Message = $"Estudiante Actualizado Exitosamente" };
                */
            }
        }
    }
}
