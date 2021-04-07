using BackEnd.Estudiante.Dominio.Repositories;
using BackEnd.Matricula.Dominio.Repositories;
using BackEnd.Mensualidad.Dominio.Repositories;
using BackEnd.PreMatricula.Dominio.Repositories;
using BackEnd.RelacionUR.Dominio.Repositories;
using BackEnd.Responsable.Dominio.Repositories;
using BackEnd.Usuario.Dominio.Repositories;
using BackEnd.Curso.Dominio.Repositories;
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
        ICursoServiceRepository CursoServiceRepository { get; }
        IUsuarioServiceRepository UsuarioServiceRepository { get; }
        IPreMatriculaServiceRepository PreMatriculaServiceRepository { get; }
        IRelacionURServiceRepository RelacionURServiceRepository { get; }
        IMensualidadServiceRepository MensualidadServiceRepository { get; }
       

        int Commit();
    }
}
