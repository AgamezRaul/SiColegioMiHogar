using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Mensualidad.Aplicacion.Service.Crear
{
    public class CrearMensualidadService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearMensualidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearMensualidadResponse Ejecutar(CrearMensualidadRequest request)
        {
            var mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.id || t.Mes == request.Mes && t.IdMatricula == request.IdMatricula && t.Año ==request.Año);
            var matricula = _unitOfWork.MatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.IdMatricula);
            var prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.Id == matricula.IdePreMatricula);
            var estudiante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.IdUsuario == prematricula.IdUsuario);
            var grado = _unitOfWork.GradoServiceRepository.FindFirstOrDefault(t => t.Nombre == estudiante.GradoEstudiante);
            var valorMensualidad = _unitOfWork.ValorMensualidadServiceRepository.FindFirstOrDefault(t => t.IdGrado == grado.Id);
            if (mensualidad != null)
            {
                return new CrearMensualidadResponse($"Mensualidad ya existe");
            }
            if (valorMensualidad == null)
            {
                return new CrearMensualidadResponse($"No exite un Grado registrado para este estudiante");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearMensualidadResponse(ListaErrors);
            }
            request.Deuda = valorMensualidad.PrecioMensualidad;
            Dominio.Mensualidad newMensualidad = new Dominio.Mensualidad(request.Mes, request.Deuda, request.Estado, request.Año, request.IdMatricula);
            _unitOfWork.MensualidadServiceRepository.Add(newMensualidad);
            _unitOfWork.Commit();
            return new CrearMensualidadResponse($"Mensualidad Creada Exitosamente");
        }
    }
}
