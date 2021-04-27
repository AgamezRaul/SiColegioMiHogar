using BackEnd.Base;
using BackEnd.Docente.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Docente.Aplicacion.Service.Eliminar
{
    public class EliminarDocenteService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarDocenteResponse Ejecutar(EliminarDocenteRequest request)
        {
            Dominio.Docente docente = _unitOfWork.DocenteServiceRepository.FindFirstOrDefault(t => t.Id == request.IdDocente);
            if (docente == null)
            {
                return new EliminarDocenteResponse() { Message = $"Docente no existe" };
            }
            else
            {
                _unitOfWork.DocenteServiceRepository.Delete(docente);
                _unitOfWork.Commit();
                return new EliminarDocenteResponse() { Message = $"Docente Eliminado Exitosamente" };
            }
        }

    }
}
