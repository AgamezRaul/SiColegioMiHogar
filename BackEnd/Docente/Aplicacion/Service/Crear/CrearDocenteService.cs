using BackEnd.Base;
using BackEnd.Docente.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Docente.Aplicacion.Service.Crear
{
    public class CrearDocenteService
    {

        readonly IUnitOfWork _unitOfWork;

        public CrearDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearDocenteResponse Ejecutar(CrearDocenteRequest request)
        {
            var docente = _unitOfWork.DocenteServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (docente == null)
            {
                Dominio.Docente newDocente = new Dominio.Docente(request.NombreCompleto, request.NumTarjetaProf, request.Cedula, request.Celular, request.Correo, request.Direccion);

                IReadOnlyList<string> errors = newDocente.CanCrear(newDocente);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearDocenteResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.DocenteServiceRepository.Add(newDocente);
                    _unitOfWork.Commit();
                    return new CrearDocenteResponse() { Message = $"Docente Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearDocenteResponse() { Message = $"Docente ya existe" };
            }
        }
    }
}
