using BackEnd.Base;
using BackEnd.Docente.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Docente.Aplicacion.Service.Actualizar
{
    public class ActualizarDocenteService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarDocenteResponse Ejecutar(ActualizarDocenteRequest request)
        {
            Dominio.Docente docente = _unitOfWork.DocenteServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (docente == null)
            {
                return new ActualizarDocenteResponse() { Message = $"Docente no existe" };
            }
            else
            {
                docente.NombreCompleto = request.NombreCompleto;
                docente.NumTarjetaProf = request.NumTarjetaProf;
                docente.Cedula = request.Cedula;
                docente.Celular = request.Celular;
                docente.Correo = request.Correo;
                docente.Direccion = request.Direccion;

                _unitOfWork.DocenteServiceRepository.Edit(docente);
                _unitOfWork.Commit();
                return new ActualizarDocenteResponse() { Message = $"Docente Actualizado Exitosamente" };

            }
        }
    }
}
