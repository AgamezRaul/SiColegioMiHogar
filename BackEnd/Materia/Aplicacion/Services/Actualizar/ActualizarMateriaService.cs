using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Base;
using BackEnd.Materia.Aplicacion.Request;

namespace BackEnd.Materia.Aplicacion.Services.Actualizar
{
    public class ActualizarMateriaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ActualizarMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarMateriaResponse Ejecutar(ActualizarMateriaRequest request)
        {
            Dominio.Entidades.Materias materia = _unitOfWork.MateriaServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (materia == null)
            {
                return new ActualizarMateriaResponse() { Message = $"La materia no existe" };
            }
            else
            {
                materia.IdDocente = request.IdDocente;
                materia.NombreMateria = request.NombreMateria;

                _unitOfWork.MateriaServiceRepository.Edit(materia);
                _unitOfWork.Commit();
                return new ActualizarMateriaResponse() { Message = $"Materia actualizado exitosamente" };

            }
        }
    }
}
