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
            Dominio.Entidades.Materias materia = _unitOfWork.MateriaServiceRepository.FindFirstOrDefault(t => t.IdDocente == request.IdDocente);
            if (materia == null)
            {
                return new ActualizarMateriaResponse() { Message = $"La materia no existe" };
            }
            else
            {
                materia.IdCurso = request.IdCurso;
                materia.IdDocente = request.IdDocente;
                materia.idMateria = request.Id;
                materia.NombreMateria = request.Nombre;

                _unitOfWork.MateriaServiceRepository.Edit(materia);
                _unitOfWork.Commit();
                return new ActualizarMateriaResponse() { Message = $"Estudiante Actualizado Exitosamente" };

            }
        }
    }
}
