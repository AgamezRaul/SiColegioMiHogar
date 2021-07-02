using BackEnd.Base;
using BackEnd.NotaPeriodo.Aplicacion.Request;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.NotaPeriodo.Aplicacion.Service.Crear
{
    public class CrearNotaPeriodoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearNotaPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearNotaPeriodoResponse Ejecutar(CrearNotaPeriodoRequest request)
        {
            var notaPeriodo = _unitOfWork.NotaPeriodoServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (notaPeriodo == null)
            {
                Dominio.NotaPeriodo newNotaPeriodo = new Dominio.NotaPeriodo(request.Nota, request.Observacion, request.IdPeriodo, request.IdMateria);

                IReadOnlyList<string> errors = newNotaPeriodo.CanCrear(newNotaPeriodo);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearNotaPeriodoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.NotaPeriodoServiceRepository.Add(newNotaPeriodo);
                    _unitOfWork.Commit();
                    return new CrearNotaPeriodoResponse() { Message = $"Nota Periodo Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearNotaPeriodoResponse() { Message = $"Nota Periodo ya existe" };
            }
        }
    }
}
