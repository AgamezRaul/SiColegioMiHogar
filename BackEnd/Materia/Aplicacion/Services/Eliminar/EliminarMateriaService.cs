using BackEnd.Base;
using BackEnd.Materia.Aplicacion.Request;

namespace BackEnd.Materia.Aplicacion.Services.Eliminar
{
    public class EliminarMateriaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarMateriaResponse Ejecutar(EliminarMateriaRequest request)
        {
            Dominio.Entidades.Materias materia = _unitOfWork.MateriaServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (materia == null)
            {
                return new EliminarMateriaResponse() { Message = $"Materia no existe" };
            }
            else
            {
                _unitOfWork.MateriaServiceRepository.Delete(materia);
                _unitOfWork.Commit();
                return new EliminarMateriaResponse() { Message = $"Materia eliminada exitosamente" };
            }
        }
    }
}
