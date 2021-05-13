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
            var mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.id || t.Mes==request.Mes && t.IdMatricula==request.IdMatricula);
            if (mensualidad != null)
            {
                return new CrearMensualidadResponse($"Mensualidad ya existe");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearMensualidadResponse(ListaErrors);
            }        
            Dominio.Mensualidad newMensualidad = new Dominio.Mensualidad(request.Mes, request.DiaPago,request.FechaPago,request.ValorMensualidad,
            request.DescuentoMensualidad,request.Abono,request.Deuda,request.Estado,request.IdMatricula,request.TotalMensualidad);
            _unitOfWork.MensualidadServiceRepository.Add(newMensualidad);
            _unitOfWork.Commit();
            return new CrearMensualidadResponse($"Mensualidad Creada Exitosamente");
        }
    }
}
