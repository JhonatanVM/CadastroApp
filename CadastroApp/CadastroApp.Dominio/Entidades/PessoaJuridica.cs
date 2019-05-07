using CadastroApp.Dominio.Entidades.EntidadeBase;
using CadastroApp.Dominio.Validacoes;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroApp.Dominio.Entidades
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica()
        {
        }

        public PessoaJuridica(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string uf,
            string cnpj, string razaoSocial, string nomeFantasia)
        {
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public override ValidationResult Validate()
        {
            ValidationResult = new PessoaJuridicaValidacao().Validate(this);
            return ValidationResult;
        }
    }
}
