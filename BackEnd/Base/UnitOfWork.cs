using BackEnd.Estudiante.Dominio.Repositories;
using BackEnd.Estudiante.Infra;
using BackEnd.Matricula.Dominio.Repositories;
using BackEnd.Matricula.Infra;
using BackEnd.Mensualidad.Dominio.Repositories;
using BackEnd.Mensualidad.Infra;
using BackEnd.PreMatricula.Dominio.Repositories;
using BackEnd.PreMatricula.Infra;
using BackEnd.Responsable.Dominio.Repositories;
using BackEnd.Responsable.Infra;
using BackEnd.Usuario.Dominio.Repositories;
using BackEnd.Usuario.Infra;
using BackEnd.Curso.Dominio.Repositories;
using BackEnd.Curso.Infra;
using BackEnd.Docente.Dominio.Repositories;
using BackEnd.Docente.Infra;
using Microsoft.EntityFrameworkCore;
using BackEnd.Nota.Dominio.Repositories;
using BackEnd.Nota.Infra;
using BackEnd.Periodo.Dominio.Repositories;
using BackEnd.Periodo.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Materia.Dominio.Repositories;
using BackEnd.Materia.Infra;
using BackEnd.NotaPeriodo.Dominio.Repositories;
using BackEnd.NotaPeriodo.Infra;
using BackEnd.Contrato.Dominio;
using BackEnd.Contrato.Infra;
using BackEnd.Actividad;
using BackEnd.Boletin.Dominio.Repositories;
using BackEnd.Boletin.Infra;

namespace BackEnd.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;
        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        //Repositorios
        private IEstudianteServiceRepository _estudianteServiceRepository;
        public IEstudianteServiceRepository EstudianteServiceRepository
        {
            get
            {
                return _estudianteServiceRepository ?? (_estudianteServiceRepository = new EstudianteServiceRepository(_dbContext));
            }
        }

        private IBoletinServiceRepository _boletinServiceRepository;
        public IBoletinServiceRepository BoletinServiceRepository
        {
            get
            {
                return _boletinServiceRepository ?? (_boletinServiceRepository = new BoletinServiceRepository(_dbContext));
            }
        }


        private IResponsableServiceRepository _responsableServiceRepository;
        public IResponsableServiceRepository ResponsableServiceRepository
        {
            get
            {
                return _responsableServiceRepository ?? (_responsableServiceRepository = new ResponsableServiceRepository(_dbContext));
            }
        }
        private IMatriculaServiceRepository _matriculaServiceRepository;
        public IMatriculaServiceRepository MatriculaServiceRepository
        {
            get
            {
                return _matriculaServiceRepository ?? (_matriculaServiceRepository = new MatriculaServiceRepository(_dbContext));
            }
        }
        private IUsuarioServiceRepository _usuarioServiceRepository;
        public IUsuarioServiceRepository UsuarioServiceRepository
        {
            get
            {
                return _usuarioServiceRepository ?? (_usuarioServiceRepository = new UsuarioServiceRepository(_dbContext));
            }
        }
        private IPreMatriculaServiceRepository _prematriculaServiceRepository;
        public IPreMatriculaServiceRepository PreMatriculaServiceRepository
        {
            get
            {
                return _prematriculaServiceRepository ?? (_prematriculaServiceRepository = new PreMatriculaServiceRepository(_dbContext));
            }
        }

        private IMensualidadServiceRepository _mensualidadServiceRepository;
        public IMensualidadServiceRepository MensualidadServiceRepository
        {
            get
            {
                return _mensualidadServiceRepository ?? (_mensualidadServiceRepository = new MensualidadServiceRepository(_dbContext));
            }
        }

        private ICursoServiceRepository _cursoServiceRepository;
        public ICursoServiceRepository CursoServiceRepository
        {
            get
            {
                return _cursoServiceRepository ?? (_cursoServiceRepository = new CursoServiceRepository(_dbContext));
            }
        }

        private IMateriaServiceRepository _materiaServiceRepository;
        public IMateriaServiceRepository MateriaServiceRepository
        {
            get
            {
                return _materiaServiceRepository ?? (_materiaServiceRepository = new MateriaServiceRepository(_dbContext));
            }
        }
        private IDocenteServiceRepository _docenteServiceRepository;
        public IDocenteServiceRepository DocenteServiceRepository
        {
            get
            {
                return _docenteServiceRepository ?? (_docenteServiceRepository = new DocenteServiceRepository(_dbContext));
            }
        }

        private INotaServiceRepository _notaServiceRepository;
        public INotaServiceRepository NotaServiceRepository
        {
            get
            {
                return _notaServiceRepository ?? (_notaServiceRepository = new NotaServiceRepository(_dbContext));
            }
        }

        private IPeriodoServiceRepository _periodoServiceRepository;
        public IPeriodoServiceRepository PeriodoServiceRepository
        {
            get
            {
                return _periodoServiceRepository ?? (_periodoServiceRepository = new PeriodoServiceRepository(_dbContext));
            }
        }

        private INotaPeriodoServiceRepository _notaPeriodoServiceRepository;
        public INotaPeriodoServiceRepository NotaPeriodoServiceRepository
        {
            get
            {
                return _notaPeriodoServiceRepository ?? (_notaPeriodoServiceRepository = new NotaPeriodoServiceRepository(_dbContext));
            }
        }

        private IContratoServiceRepository _contratoServiceRepository;
        public IContratoServiceRepository ContratoServiceRepository
        {
            get
            {
                return _contratoServiceRepository ?? (_contratoServiceRepository = new ContratoServiceRepository(_dbContext));
            }
        }
        private IActividadServiceRepository _actividadServiceRepository;
        public IActividadServiceRepository ActividadServiceRepository
        {
            get
            {
                return _actividadServiceRepository ?? (_actividadServiceRepository = new ActividadServiceRepository(_dbContext));
            }
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
