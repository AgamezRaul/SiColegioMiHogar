using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Base;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Abono.Aplicacion.Service.Crear
{
    public class CrearAbonoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearAbonoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearAbonoResponse Ejecutar(CrearAbonoRequest request)
        {
            var abono = _unitOfWork.AbonoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (abono != null)
            {
                return new CrearAbonoResponse($"Abono ya existe");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearAbonoResponse(ListaErrors);
            }
            Dominio.Abono newAbono = new Dominio.Abono(request.Mes, request.FechaPago, request.ValorAbono, request.EstadoAbono, request.IdMensualidad);
            _unitOfWork.AbonoServiceRepository.Add(newAbono);
            _unitOfWork.Commit();
            return new CrearAbonoResponse($"Abono Creado Exitosamente");
        }
    }
}
