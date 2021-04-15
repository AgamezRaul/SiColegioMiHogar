using BackEnd.Estudiante.Dominio.Repositories;
using BackEnd.Matricula.Dominio.Repositories;
using BackEnd.Mensualidad.Dominio.Repositories;
using BackEnd.PreMatricula.Dominio.Repositories;
using BackEnd.Responsable.Dominio.Repositories;
using BackEnd.Usuario.Dominio.Repositories;
using BackEnd.Curso.Dominio.Repositories;
using BackEnd.Docente.Dominio.Repositories;
using BackEnd.Nota.Dominio.Repositories;
using BackEnd.Periodo.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.materias.Dominio.Repositories;

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
        IMensualidadServiceRepository MensualidadServiceRepository { get; }
        IMateriaServiceRepository MateriaServiceRepository { get; }
        IDocenteServiceRepository DocenteServiceRepository { get;  }
        InotaServiceRepository NotaServiceRepository { get; }
        IPeriodoServiceRepository PeriodoServiceRepository { get; }

        int Commit();
    }
}
