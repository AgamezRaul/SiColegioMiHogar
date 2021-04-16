using BackEnd.Base;
using BackEnd.materias.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.materias.Aplicacion.Services.Crear
{
    public class CrearMateriaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearMateriaResponse Ejecutar(CrearMateriaRequest request)
        {
            var materia = _unitOfWork.MateriaServiceRepository.FindFirstOrDefault(t => t.NombreMateria == request.NombreMateria);

            if (materia == null)
            {
                Dominio.Entidades.Materias newMateria = new Dominio.Entidades.Materias(request.NombreMateria, request.IdDocente, request.IdCurso);

                IReadOnlyList<string> errors = newMateria.CanCrear(newMateria);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearMateriaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.MateriaServiceRepository.Add(newMateria);
                    _unitOfWork.Commit();
                    return new CrearMateriaResponse() { Message = $"Materia creada exitosamente" };
                }
            }
            else
            {
                return new CrearMateriaResponse() { Message = $"Materia ya existe" };
            }
        }

    }
}
