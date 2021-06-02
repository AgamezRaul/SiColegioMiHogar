using BackEnd.Base;
using BackEnd.Boletin.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Boletin.Aplicacion.Services.Crear
{
    public class CrearBoletinService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearBoletinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearBoletinResponse Ejecutar(CrearBoletinRequest request)
        {
            var boletin = _unitOfWork.BoletinServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (boletin == null)
            {
                Dominio.Boletin newBoletin = new Dominio.Boletin(request.IdEstudiante, request.IdPeriodo, request.FechaGeneracion);


                IReadOnlyList<string> errors = newBoletin.CanCrear(newBoletin);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearBoletinResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.BoletinServiceRepository.Add(newBoletin);
                    _unitOfWork.Commit();
                    return new CrearBoletinResponse() { Message = $"Boletin Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearBoletinResponse() { Message = $"Boletin ya existe" };
            }
        }
    }
}
