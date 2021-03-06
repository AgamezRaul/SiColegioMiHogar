using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;

namespace BackEnd.Nota.Aplicacion.Services
{
    public class ActualizarNotaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ActualizarNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public ActualizarResponse ActualizarNota(CrearNotaRequest request)
        {
            var Buscar = _unitOfWork.NotaServiceRepository.FindFirstOrDefault(P => P.Id == request.Id);
            if (Buscar != null)
            {
                Buscar.FechaNota = request.FechaNota;
                Buscar.NotaAlumno = request.NotaAlumno;

                _unitOfWork.NotaServiceRepository.Edit(Buscar);
                if (_unitOfWork.Commit() > 0)
                {
                    return new ActualizarResponse() { Message = $"Los datos de la nota fueron actualizados correctamente." };

                }
                else
                {
                    return new ActualizarResponse() { Message = $"Ocurrio un error al tratar de actualizar la nota." };

                }
            }
            else
            {
                return new ActualizarResponse() { Message = $"No Existe esa nota Cachon" };

            }

        }
    }

    public class ActualizarResponse
    {
        public string Message { get; set; }
    }
}
