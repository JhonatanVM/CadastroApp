using CadastroApp.Dominio.Entidades.EntidadeBase;
using CadastroApp.Dominio.Validacoes;
using FluentValidation.Results;
using System;

namespace CadastroApp.Dominio.Entidades
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica()
        {
        }

        public PessoaFisica(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string uf,
            string cpf, DateTime dataDeNascimento, string nome, string sobrenome)
        {
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
        public override ValidationResult Validate()
        {
            ValidationResult = new PessoaFisicaValidacao().Validate(this);
            return ValidationResult;
        }
    }
}
