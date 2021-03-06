using Microsoft.EntityFrameworkCore;

namespace FiapWebservicesRestfulTechnologies.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
