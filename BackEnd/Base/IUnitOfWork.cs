﻿using BackEnd.Estudiante.Dominio.Repositories;
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
using BackEnd.Materia.Dominio.Repositories;
using BackEnd.NotaPeriodo.Dominio.Repositories;
using BackEnd.Boletin.Dominio.Repositories;
using BackEnd.Contrato.Dominio;
using BackEnd.Actividad;
using BackEnd.EstudianteCurso.Dominio;

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
        INotaServiceRepository NotaServiceRepository { get; }
        IPeriodoServiceRepository PeriodoServiceRepository { get; }
        INotaPeriodoServiceRepository NotaPeriodoServiceRepository { get; }
        IContratoServiceRepository ContratoServiceRepository { get; }
        IActividadServiceRepository ActividadServiceRepository { get; }
        IEstudianteCursoServiceRepository EstudianteCursoServiceRepository { get; }

        IBoletinServiceRepository BoletinServiceRepository { get; }
        int Commit();
    }
}
