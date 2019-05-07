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
                .WithMessage("CEP deve ter 8 digitos.");

            RuleFor(e => e.Logradouro)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Logradouro é obrigatório.")
                .Length(1, 50)
                .WithMessage("Logradouro deve ter entre 1 e 50 caractéres.");

            RuleFor(e => e.Numero)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Numero é obrigatório.")
                .Length(1, 50)
                .WithMessage("Numero deve ter entre 1 e 50 caractéres");

            RuleFor(e => e.Bairro)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Bairro é obrigatório.")
                .Length(1, 50)
                .WithMessage("Bairro deve ter entre 1 e 50 caractéres.");

            RuleFor(e => e.Cidade)
                .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                .WithMessage("Cidade é obrigatória.")
                .Length(1, 50)
                .WithMessage("Cidade deve ter entre 1 e 40 caractéres.");

            RuleFor(e => e.UF)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Estado é obrigatório.")
                .Length(1, 50)
                .WithMessage("Estado deve ter entre 1 e 50 caractéres.");



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
                .Length(1, 50)
                .WithMessage("Nome deve ter entre 1 e 50 caractéres.");

            RuleFor(e => e.Sobrenome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Sobrenome é obrigatório.")
                .Length(1, 50)
                .WithMessage("Sobrenome deve ter entre 1 e 50 caractéres.");
        }
    }
}
