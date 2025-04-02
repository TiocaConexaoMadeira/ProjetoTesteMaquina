using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Model.Cadastro;
using ProjetoTeste.Model.Security;

namespace ProjetoTeste.Infra.Database
{
    public class ProjetoTesteContext : DbContext
    {
        public ProjetoTesteContext(DbContextOptions<ProjetoTesteContext> options) : base(options) { }

        public DbSet<Maquina> Maquinas { get; set; } // Ajuste conforme suas entidades
        public DbSet<Login> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maquina>()
                .HasKey(m => m.Codigo);

            base.OnModelCreating(modelBuilder);
        }
    }
}
