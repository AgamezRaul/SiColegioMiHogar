using BackEnd.Estudiante.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IEstudianteServiceRepository EstudianteServiceRepository { get; }

        int Commit();
    }
}
