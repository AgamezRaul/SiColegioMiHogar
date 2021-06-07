using BackEnd.Base;
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
        public DbSet<Responsable.Dominio.Responsable> Responsable { get; set; }
        public DbSet<Usuario.Dominio.Usuario> Usuario { get; set; }
        public DbSet<Mensualidad.Dominio.Mensualidad> Mensualidad { get; set; }
        public DbSet<Curso.Dominio.Curso> Curso { get; set; }
        public DbSet<Materia.Dominio.Entidades.Materias> Materia { get; set; }
        public DbSet<Docente.Dominio.Docente> Docente { get; set; }
        public DbSet<NotaPeriodo.Dominio.NotaPeriodo> NotaPeriodo { get; set; }
        public DbSet<Contrato.Dominio.Contrato> Contrato { get; set; }
        public DbSet<Actividad.Actividad> Actividad { get; set; }
        public DbSet<EstudianteCurso.Dominio.EstudianteCurso> EstudianteCurso { get; set; }
        public DbSet<Boletin.Dominio.Boletin> Boletin { get; set; }
    }
}
