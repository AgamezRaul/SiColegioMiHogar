using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BackEnd.Periodo.Aplicacion.Services
{
    public class EliminarPeriodoService
    {
        readonly IUnitOfWork _unitOfWork;


        public EliminarPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public EliminarPeriodoResponse DeletePeridodo(int id)
        {

            Dominio.Periodo periodo = _unitOfWork.PeriodoServiceRepository.FindFirstOrDefault(x => x.Id == id);

            if (periodo == null)
            {
                return new EliminarPeriodoResponse() { Message = $"No Existe ese periodo" };
            }
            else
            {
                _unitOfWork.PeriodoServiceRepository.Delete(periodo);
                if (_unitOfWork.Commit() > 0)
                {
                    return new EliminarPeriodoResponse() { Message = $"Se Elimio el periodo" };
                }
                else
                {
                    return new EliminarPeriodoResponse() { Message = $"Ocurrio un error al eliminar el periodo." };
                }
            }
        }
    }

    public class EliminarPeriodoResponse
    {
        public string Message { get; set; }
    }
}
