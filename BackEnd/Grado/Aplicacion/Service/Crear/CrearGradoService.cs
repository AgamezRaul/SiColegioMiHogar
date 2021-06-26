using BackEnd.Base;
using BackEnd.Grado.Aplicacion.Request;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Grado.Aplicacion.Service.Crear
{
    public class CrearGradoService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearGradoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearGradoResponse Ejecutar(CrearGradoRequest request)
        {
            var grado = _unitOfWork.GradoServiceRepository.FindFirstOrDefault(t => t.Id == request.id || t.Nombre == request.Nombre);
            if (grado != null)
            {
                return new CrearGradoResponse($"Grado ya existe");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearGradoResponse(ListaErrors);
            }
            Dominio.Grado newGrado = new Dominio.Grado(request.Nombre.ToUpper());
            _unitOfWork.GradoServiceRepository.Add(newGrado);
            _unitOfWork.Commit();
            return new CrearGradoResponse($"Grado Creado Exitosamente");
        }
    }
}
