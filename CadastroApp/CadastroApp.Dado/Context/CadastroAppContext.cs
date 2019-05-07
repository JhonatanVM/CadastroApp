using CadastroApp.Dado.EntityTypeConfiguration;
using CadastroApp.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CadastroApp.Dado.Context
{
    public class CadastroAppContext : DbContext
    {
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }

        public CadastroAppContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionString.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new PessoaFisicaTypeConfiguration())
                .ApplyConfiguration(new PessoaJuridicaTypeConfiguration());
        }
    }
}
