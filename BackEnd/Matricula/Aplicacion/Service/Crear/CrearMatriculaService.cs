using BackEnd.Base;
using BackEnd.Matricula.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Matricula.Aplicacion.Service.Crear
{
   public class CrearMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearMatriculaResponse Ejecutar(CrearMatriculaRequest request)
        {
            var matricula = _unitOfWork.MatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (matricula == null)
            {
                Dominio.Matricula newMatricula = new Dominio.Matricula(request.FecConfirmacion, request.IdePreMatricula);

                IReadOnlyList<string> errors = newMatricula.CanCrear(newMatricula);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearMatriculaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.MatriculaServiceRepository.Add(newMatricula);
                    _unitOfWork.Commit();
                    return new CrearMatriculaResponse() { Message = $"Matricula Creada Exitosamente" };
                }
            }
            else
            {
                return new CrearMatriculaResponse() { Message = $"Matricula ya existe" };
            }
        }
    }
}
