using CadastroApp.Dominio.Entidades;
using FluentValidation;
using System;

namespace CadastroApp.Dominio.Validacoes
{
    public class PessoaFisicaValidacao : AbstractValidator<PessoaFisica>
    {
        public PessoaFisicaValidacao()
        {
            Validacoes();
        }

        private void Validacoes()
        {
            RuleFor(e => e.CEP)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("CEP é obrigatório.")
                .Length(8)
                .WithMessage("CEP deve ter 8 dígitos.");

            RuleFor(e => e.Logradouro)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Logradouro é obrigatório.")
                .Length(1, 100)
                .WithMessage("Logradouro deve ter entre 1 e 100 caracteres.");

            RuleFor(e => e.Numero)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Numero é obrigatório.")
                .Length(1, 10)
                .WithMessage("Numero deve ter entre 1 e 10 caracteres");

            RuleFor(e => e.Bairro)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Bairro é obrigatório.")
                .Length(1, 50)
                .WithMessage("Bairro deve ter entre 1 e 50 caracteres.");

            RuleFor(e => e.Cidade)
                .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                .WithMessage("Cidade é obrigatório.")
                .Length(1, 50)
                .WithMessage("Cidade deve ter entre 1 e 50 caracteres.");

            RuleFor(e => e.UF)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("UF é obrigatório.")
                .Length(2)
                .WithMessage("UF deve ter 2 caracteres.");



            RuleFor(e => e.CPF)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("CPF é obrigatório.")
                .Length(11)
                .WithMessage("Cpf deve ter 11 digitos.");

            RuleFor(e => e.DataDeNascimento)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(DateTime.MinValue)
                .WithMessage("Data de Nascimento é obrigatório.")
                .LessThanOrEqualTo(DateTime.Now.AddYears(-19))
                .WithMessage("Você deve ter no minimo 19 anos.");

            RuleFor(e => e.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(1, 15)
                .WithMessage("Nome deve ter entre 1 e 15 caracteres.");

            RuleFor(e => e.Sobrenome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Sobrenome é obrigatório.")
                .Length(1, 15)
                .WithMessage("Sobrenome deve ter entre 1 e 15 caracteres.");
        }
    }
}
