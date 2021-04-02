﻿using BackEnd.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class MiHogarContextTest : DbContextBase
    {
        public MiHogarContextTest(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=BdColegioMiHogar; Integrated Security=True; MultipleActiveResultSets=True");*/
        }

        public DbSet<Estudiante.Dominio.Estudiante> Estudiante { get; set; }
        public DbSet<Matricula.Dominio.Matricula> Matricula { get; set; }
        public DbSet<PreMatricula.Dominio.PreMatricula> PreMatricula { get; set; }
        public DbSet<RelacionUR.Dominio.RelacionUR> RelacionUR { get; set; }
        public DbSet<Responsable.Dominio.Responsable> Responsable { get; set; }
        public DbSet<Usuario.Dominio.Usuario> Usuario { get; set; }
    }
}
