using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;

namespace BackEnd.Estudiante.Aplicacion.Services.Actualizar
{
    public class ActualizarEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarEstudianteResponse Ejecutar(ActualizarEstudianteRequest request)
        {
            Dominio.Estudiante estudiante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.IdeEstudiante == request.IdeEstudiante);
            if (estudiante == null)
            {
                return new ActualizarEstudianteResponse() { Message = $"Estudiante no existe" };
            }
            else
            {
                estudiante.IdeEstudiante = request.IdeEstudiante;
                estudiante.NomEstudiante = request.NomEstudiante;
                estudiante.FecNacimiento = request.FecNacimiento;
                estudiante.LugNacimiento = request.LugNacimiento;
                estudiante.LugExpedicion = request.LugExpedicion;
                estudiante.InsProcedencia = request.InsProcedencia;
                estudiante.DirResidencia = request.DirResidencia;
                estudiante.CelEstudiante = request.CelEstudiante;
                estudiante.TipSangre = request.TipSangre;
                estudiante.GradoEstudiante = request.GradoEstudiante;
                estudiante.Eps = request.Eps;
                estudiante.Correo = request.Correo;
                estudiante.Sexo = request.Sexo;
                estudiante.TipoDocumento = request.TipoDocumento;
                estudiante.TelEstudiante = request.TelEstudiante;

                _unitOfWork.EstudianteServiceRepository.Edit(estudiante);
                _unitOfWork.Commit();
                return new ActualizarEstudianteResponse() { Message = $"Estudiante Actualizado Exitosamente" };

            }
        }
    }
}