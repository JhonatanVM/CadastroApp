using CadastroApp.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroApp.Dado.EntityTypeConfiguration
{
    class PessoaJuridicaTypeConfiguration : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            ConfigurarNomeDaTabela(builder);
            ConfigurarChavePrimaria(builder);
            ConfigurarPropriedades(builder);
            ConfigurarIdentidade(builder);
        }

        private void ConfigurarNomeDaTabela(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder
                .ToTable("PessoaJuridica", "dbo");
        }

        private void ConfigurarChavePrimaria(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder
                .HasKey(e => new { e.Id });
        }

        private void ConfigurarPropriedades(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.Property(con => con.Id).HasColumnName("Id");
            builder.Property(con => con.CEP).HasColumnName("CEP");
            builder.Property(con => con.Logradouro).HasColumnName("Logradouro");
            builder.Property(con => con.Numero).HasColumnName("Numero");
            builder.Property(con => con.Complemento).HasColumnName("Complemento");
            builder.Property(con => con.Bairro).HasColumnName("Bairro");
            builder.Property(con => con.Cidade).HasColumnName("Cidade");
            builder.Property(con => con.UF).HasColumnName("UF");

            builder.Property(con => con.CNPJ).HasColumnName("CNPJ");
            builder.Property(con => con.RazaoSocial).HasColumnName("RazaoSocial");
            builder.Property(con => con.NomeFantasia).HasColumnName("NomeFantasia");
        }

        private void ConfigurarIdentidade(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder
                .Property(e => e.Id)
                .UseSqlServerIdentityColumn();
        }
    }
}
