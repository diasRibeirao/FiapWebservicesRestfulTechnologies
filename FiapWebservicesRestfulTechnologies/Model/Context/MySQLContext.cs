using Microsoft.EntityFrameworkCore;

namespace FiapWebservicesRestfulTechnologies.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<Medico> Medicos { get; set; }
    }
}
