using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Estudiante.Aplicacion.Services.Crear
{
    public class CrearEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearEstudianteResponse Ejecutar(CrearEstudianteRequest request)
        {
            var estudiante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.IdeEstudiante == request.IdeEstudiante);
            if (estudiante != null)
            {
                return new CrearEstudianteResponse($"Estudiante ya existe");
            }
            //Patrones de validaciones de dominios
            Dominio.Estudiante newEstudiante = new Dominio.Estudiante(request.IdeEstudiante, request.NomEstudiante, request.FecNacimiento, request.LugNacimiento,
                request.LugExpedicion, request.InsProcedencia, request.DirResidencia, request.CelEstudiante, request.TipSangre, request.GradoEstudiante, request.Eps,
                request.Correo, request.Sexo, request.TipoDocumento, request.TelEstudiante, request.IdUsuario);
            _unitOfWork.EstudianteServiceRepository.Add(newEstudiante);
            return new CrearEstudianteResponse($"Estudiante Creado Exitosamente");
        }

    }
}

