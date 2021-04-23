using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Nota.Aplicacion.Services
{
    public class EliminarNotaService
    {
        readonly IUnitOfWork _unitOfWork;


        public EliminarNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public EliminarResponse DeleteNota(int id)
        {

            Dominio.Entidades.Nota nota = _unitOfWork.NotaServiceRepository.FindFirstOrDefault(x  => x.Id == id);

            if (nota == null)
            {
                return new EliminarResponse() { Message = $"No Existe esa nota" };
            }
            else
            {
                _unitOfWork.NotaServiceRepository.Delete(nota);
                if (_unitOfWork.Commit() > 0)
                {
                    return new EliminarResponse() { Message = $"Se Elimio la nota" };
                }
                else
                {
                    return new EliminarResponse() { Message = $"Ocurrio un error al eliminar la nota." };
                }
            }
        }

    }

    public class EliminarResponse
    {
        public string Message { get; set; }
    }
}
