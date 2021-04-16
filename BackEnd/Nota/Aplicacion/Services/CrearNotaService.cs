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
        public CrearNotaResponse Ejecutar(CrearNotaRequest request)
        {
            var nota  = _unitOfWork.NotaServiceRepository.FindFirstOrDefault(t => t.IdMateria == request.IdMateria && t.IdEstudiante == request.IdEstudiante && t.IdPeriodo == request.IdPeriodo);
            if (nota == null)
            {
                Dominio.Entidades.Nota newNota = new Dominio.Entidades.Nota(request.Descripcion, request.FechaNota, request.Nota, request.IdEstudiante, request.IdMateria, request.IdPeriodo);

                IReadOnlyList<string> errors = newNota.CanCrear(newNota);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearNotaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.NotaServiceRepository.Add(newNota);
                    _unitOfWork.Commit();
                    return new CrearNotaResponse() { Message = $"Nota Registrada Exitosamente" };
                }
            }
            else
            {
                return new CrearNotaResponse() { Message = $"Nota ya registrada" };
            }
        }
    }
}
