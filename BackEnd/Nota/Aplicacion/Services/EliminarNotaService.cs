using BackEnd.Base;

namespace BackEnd.Nota.Aplicacion.Services
{
    public class EliminarNotaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarNotaResponse EjecutarEliminarNota(int id)
        {
            Dominio.Entidades.Nota nota = _unitOfWork.NotaServiceRepository.FindFirstOrDefault(x => x.Id == id);
            if (nota == null)
            {
                return new EliminarNotaResponse($"Nota no existe");
            }
            else
            {
                _unitOfWork.NotaServiceRepository.Delete(nota);
                return new EliminarNotaResponse($"Nota eliminada exitosamente");
            }
        }

    }

    public class EliminarNotaResponse
    {
        public EliminarNotaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Nota eliminada exitosamente");
        }
    }
}
