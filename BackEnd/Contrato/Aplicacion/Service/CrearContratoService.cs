using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Contrato.Aplicacion.Service
{
    public class CrearContratoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearContratoResponse EjecutarCrearContrato(CrearContratoRequest request) 
        {
            var contrato = _unitOfWork.ContratoServiceRepository.FindFirstOrDefault(t => t.IdDocente == request.IdDocente);
            if (contrato != null)
            {
                return new CrearContratoResponse($"El docente ya tiene un contrato");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearContratoResponse(ListaErrors);
            }
            Dominio.Contrato newContrato = new Dominio.Contrato(request.FechaInicio, request.FechaFin, request.Sueldo, request.IdDocente);
            _unitOfWork.ContratoServiceRepository.Add(newContrato);
            _unitOfWork.Commit();
            return new CrearContratoResponse($"Contrato Creado Exitosamente");
        }
    }
}
