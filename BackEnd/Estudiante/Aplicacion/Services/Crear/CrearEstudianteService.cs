using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            if (estudiante == null)
            {
                Dominio.Estudiante newEstudiante = new Dominio.Estudiante(request.IdeEstudiante, request.NomEstudiante, request.FecNacimiento, request.LugNacimiento, 
                    request.LugExpedicion, request.InsProcedencia, request.DirResidencia, request.CelEstudiante, request.TipSangre, request.GradoEstudiante, request.Eps, 
                    request.Correo, request.Sexo, request.TipoDocumento, request.TelEstudiante);

                IReadOnlyList<string> errors = newEstudiante.CanCrear(newEstudiante);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearEstudianteResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.EstudianteServiceRepository.Add(newEstudiante);
                    _unitOfWork.Commit();
                    return new CrearEstudianteResponse() { Message = $"Estudiante Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearEstudianteResponse() { Message = $"Estudiante ya existe" };
            }
        }
    }
}
