using BackEnd.Estudiante.Dominio.Repositories;
using BackEnd.Matricula.Dominio.Repositories;
using BackEnd.Responsable.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IEstudianteServiceRepository EstudianteServiceRepository { get; }
        IResponsableServiceRepository ResponsableServiceRepository { get; }
        IMatriculaServiceRepository MatriculaServiceRepository { get; }

        int Commit();
    }
}
