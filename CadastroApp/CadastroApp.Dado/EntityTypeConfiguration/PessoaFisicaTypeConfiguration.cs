using CadastroApp.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroApp.Dado.EntityTypeConfiguration
{
    public class PessoaFisicaTypeConfiguration : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            ConfigurarNomeDaTabela(builder);
            ConfigurarChavePrimaria(builder);
            ConfigurarPropriedades(builder);
            ConfigurarIdentidade(builder);
        }

        private void ConfigurarNomeDaTabela(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder
                .ToTable("PessoaFisica", "dbo");
        }

        private void ConfigurarChavePrimaria(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder
                .HasKey(e => new { e.Id });
        }

        private void ConfigurarPropriedades(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.Property(con => con.Id).HasColumnName("Id");
            builder.Property(con => con.CEP).HasColumnName("CEP");
            builder.Property(con => con.Logradouro).HasColumnName("Logradouro");
            builder.Property(con => con.Numero).HasColumnName("Numero");
            builder.Property(con => con.Complemento).HasColumnName("Complemento");
            builder.Property(con => con.Bairro).HasColumnName("Bairro");
            builder.Property(con => con.Cidade).HasColumnName("Cidade");
            builder.Property(con => con.UF).HasColumnName("UF");

            builder.Property(con => con.CPF).HasColumnName("CPF");
            builder.Property(con => con.DataDeNascimento).HasColumnName("DataDeNascimento");
            builder.Property(con => con.Nome).HasColumnName("Nome");
            builder.Property(con => con.Sobrenome).HasColumnName("Sobrenome");
        }

        private void ConfigurarIdentidade(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder
                .Property(e => e.Id)
                .UseSqlServerIdentityColumn();
        }
    }
}
