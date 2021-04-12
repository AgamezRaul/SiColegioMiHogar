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
                docente.NombreCompleto = request.Cedula;
                docente.NumTarjetaProf = request.Celular;
                docente.Cedula = request.Correo;
                docente.Celular = request.Direccion;
                docente.Correo = request.NombreCompleto;
                docente.Direccion = request.NumTarjetaProf;

                _unitOfWork.DocenteServiceRepository.Edit(docente);
                _unitOfWork.Commit();
                return new ActualizarDocenteResponse() { Message = $"Docente Actualizado Exitosamente" };

            }
        }
    }
}
