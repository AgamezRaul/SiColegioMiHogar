﻿using BackEnd.Estudiante.Dominio.Repositories;
using BackEnd.Estudiante.Infra;
using BackEnd.Matricula.Dominio.Repositories;
using BackEnd.Matricula.Infra;
using BackEnd.Responsable.Dominio.Repositories;
using BackEnd.Responsable.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        private IResponsableServiceRepository _responsableServiceRepository;
        private IMatriculaServiceRepository _matriculaServiceRepository;

        public IEstudianteServiceRepository EstudianteServiceRepository
        {
            get
            {
                return _estudianteServiceRepository ?? (_estudianteServiceRepository = new EstudianteServiceRepository(_dbContext));
            }
        }
        public IResponsableServiceRepository ResponsableServiceRepository
        {
            get
            {
                return _responsableServiceRepository ?? (_responsableServiceRepository = new ResponsableServiceRepository(_dbContext));
            }
        }
        public IMatriculaServiceRepository MatriculaServiceRepository
        {
            get
            {
                return _matriculaServiceRepository ?? (_matriculaServiceRepository = new MatriculaServiceRepository(_dbContext));
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
