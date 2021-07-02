using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BackEnd
{
    public class AppDbContext : IDesignTimeDbContextFactory<MiHogarContext>
    {
        public MiHogarContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MiHogarContext>();
            optionsBuilder.UseSqlServer("Data Source=SQLEXPRESS; Initial Catalog=BdColegioMiHogar Trusted_Connection=True;");
            return new MiHogarContext(optionsBuilder.Options);

        }
    }
}
