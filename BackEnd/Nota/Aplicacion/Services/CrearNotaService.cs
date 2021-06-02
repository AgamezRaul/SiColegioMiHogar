using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Nota.Aplicacion.Services
{
    public class CrearNotaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearNotaResponse Ejecutar(List<CrearNotaRequest> requests)
        {
            foreach (var request in requests)
            {
                var nota = _unitOfWork.NotaServiceRepository.FindFirstOrDefault(t => t.IdActividad == request.IdActividad && t.IdEstudiante == request.IdEstudiante);
                if (nota != null)
                {
                    return new CrearNotaResponse($"Nota ya registrada");
                }
                Dominio.Entidades.Nota newNota = new Dominio.Entidades.Nota(request.NotaAlumno, request.FechaNota, request.IdActividad, request.IdEstudiante);
                IReadOnlyList<string> errors = newNota.CanCrear(newNota);
                if (errors.Any())
                {
                    string ListaErrors = "Errores: " + string.Join(",", errors);
                    return new CrearNotaResponse(ListaErrors);
                }
                _unitOfWork.NotaServiceRepository.Add(newNota);
            }            
            _unitOfWork.Commit();
            return new CrearNotaResponse($"Notas Registradas Exitosamente");
        }
    }
}
