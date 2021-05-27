using BackEnd.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BackEnd
{
    public class MiHogarContext : DbContextBase
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=BdColegioMiHogar; Integrated Security=True; MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Periodo.Dominio.Periodo>().HasData(
                    new Periodo.Dominio.Periodo() 
                    {
                        Id=1,
                        NombrePeriodo="Primer Periodo",
                        NumeroPeriodo=1,
                        FechaInicio= DateTime.Today.Date.AddDays(-5),
                        FechaFin= DateTime.Today.Date.AddDays(5)
                    },
                    new Periodo.Dominio.Periodo()
                    {
                        Id = 2,
                        NombrePeriodo = "Segundo Periodo",
                        NumeroPeriodo = 2,
                        FechaInicio = DateTime.Today.Date.AddDays(6),
                        FechaFin = DateTime.Today.Date.AddDays(16)
                    },
                    new Periodo.Dominio.Periodo()
                    {
                        Id = 3,
                        NombrePeriodo = "Tercer Periodo",
                        NumeroPeriodo = 3,
                        FechaInicio = DateTime.Today.Date.AddDays(17),
                        FechaFin = DateTime.Today.Date.AddDays(27)
                    },
                    new Periodo.Dominio.Periodo()
                    {
                        Id = 4,
                        NombrePeriodo = "Cuarto Periodo",
                        NumeroPeriodo = 4,
                        FechaInicio = DateTime.Today.Date.AddDays(28),
                        FechaFin = DateTime.Today.Date.AddDays(38)
                    }
                );
        }
            public MiHogarContext(DbContextOptions options) : base(options)
        {
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
        public DbSet<Nota.Dominio.Entidades.Nota> Nota { get; set; }
        public DbSet<Periodo.Dominio.Periodo> Periodo { get; set; }
        public DbSet<NotaPeriodo.Dominio.NotaPeriodo> NotaPeriodo { get; set; }
        public DbSet<Contrato.Dominio.Contrato> Contrato { get; set; }
        public DbSet<Actividad.Actividad> Actividad { get; set; }
    }
}
