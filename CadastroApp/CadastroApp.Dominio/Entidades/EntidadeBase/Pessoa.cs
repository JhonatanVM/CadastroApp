using CadastroApp.Dominio.Validacoes;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroApp.Dominio.Entidades.EntidadeBase
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public abstract ValidationResult Validate();
    }
}
