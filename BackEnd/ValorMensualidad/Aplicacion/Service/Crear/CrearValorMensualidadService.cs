using BackEnd.Base;
using BackEnd.ValorMensualidad.Aplicacion.Request;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.ValorMensualidad.Aplicacion.Service.Crear
{
    public class CrearValorMensualidadService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearValorMensualidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearValorMensualidadResponse Ejecutar(CrearValorMensualidadRequest request)
        {
            var valorMensualidad = _unitOfWork.ValorMensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.id || t.IdGrado == request.IdGrado && t.Año == request.Año);
            if (valorMensualidad != null)
            {
                return new CrearValorMensualidadResponse($"Valor Mensualidad ya existe");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearValorMensualidadResponse(ListaErrors);
            }
            Dominio.ValorMensualidad newValorMensualidad = new Dominio.ValorMensualidad(request.Fecha, request.Año, request.PrecioMensualidad, request.IdGrado);
            _unitOfWork.ValorMensualidadServiceRepository.Add(newValorMensualidad);
            _unitOfWork.Commit();
            return new CrearValorMensualidadResponse($"Valor Mensualidad Creado Exitosamente");
        }
    }
}
