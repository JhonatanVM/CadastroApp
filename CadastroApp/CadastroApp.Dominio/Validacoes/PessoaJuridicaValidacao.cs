using CadastroApp.Dominio.Entidades;
using FluentValidation;

namespace CadastroApp.Dominio.Validacoes
{
    public class PessoaJuridicaValidacao : AbstractValidator<PessoaJuridica>
    {
        public PessoaJuridicaValidacao()
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
                .Length(1, 8)
                .WithMessage("UF deve ter entre 1 e 8 caracteres.");


            RuleFor(e => e.CNPJ)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("CNPJ é obrigatório.")
                .Length(14)
                .WithMessage("CNPJ deve ter 14 dígitos.");

            RuleFor(e => e.RazaoSocial)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Razao Social é obrigatório.")
                .Length(1, 50)
                .WithMessage("Razão Social deve ter entre 1 e 50 caracteres.");

            RuleFor(e => e.NomeFantasia)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Nome Fantasia é obrigatório.")
                .Length(1, 50)
                .WithMessage("Nome Fantasia deve ter entre 1 e 50 caracteres.");
        }
    }
}
