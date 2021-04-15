using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Nota.Aplicacion.Services
{
    public class CrearNotaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public NotaResponse Ejecutar(NotaRequest request)
        {
            var nota  = _unitOfWork.NotaServiceRepository.FindFirstOrDefault(t => t.IdMateria == request.IdMateria && t.IdEstudiante == request.IdEstudiante && t.IdPeriodo == request.IdPeriodo);
            if (nota == null)
            {
                Dominio.Entidades.Nota newNota = new Dominio.Entidades.Nota(request.Descripcion, request.NotaAlumno, request.IdEstudiante, request.IdMateria, request.IdPeriodo);

                IReadOnlyList<string> errors = newNota.CanCrear(newNota);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new NotaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.NotaServiceRepository.Add(newNota);
                    _unitOfWork.Commit();
                    return new NotaResponse() { Message = $"Nota Registrada Exitosamente" };
                }
            }
            else
            {
                return new NotaResponse() { Message = $"Este estudiante ya tiene la nota de esta materia para el periodo que desea ingresar" };
            }
        }
    }
}
