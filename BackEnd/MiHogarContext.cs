using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BackEnd
{
    public class MiHogarContext : DbContext
    {
        public MiHogarContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=BdColegioMiHogar; Integrated Security=True; MultipleActiveResultSets=True");
        }

        public DbSet<Estudiante.Dominio.Estudiante> Estudiante { get; set; }
    }
}
