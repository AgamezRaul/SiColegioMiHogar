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
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-FDBCSN1\SQLEXPRESS;Database=BdColegioMiHogar;Integrated Security=True;");
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
    }
}
