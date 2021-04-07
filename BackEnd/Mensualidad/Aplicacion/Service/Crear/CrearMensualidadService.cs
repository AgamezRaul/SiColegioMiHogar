using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (mensualidad == null)
            {
                Dominio.Mensualidad newMensualidad = new Dominio.Mensualidad(request.Mes, request.DiaPago,request.FechaPago,request.ValorMensualidad,
                    request.DescuentoMensualidad,request.Abono,request.Deuda,request.Estado,request.IdMatricula,request.TotalMensualidad);
            
                IReadOnlyList<string> errors = newMensualidad.CanCrear(newMensualidad);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearMensualidadResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.MensualidadServiceRepository.Add(newMensualidad);
                    _unitOfWork.Commit();
                    return new CrearMensualidadResponse() { Message = $"Mensualidad Creada Exitosamente" };
                }
            }
            else
            {
                return new CrearMensualidadResponse() { Message = $"Mensualidad ya existe" };
            }
        }
    }
}
