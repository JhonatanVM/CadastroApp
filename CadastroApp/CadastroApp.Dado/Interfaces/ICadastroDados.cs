using CadastroApp.Dominio.Entidades;

namespace CadastroApp.Dado.Interfaces
{
    public interface ICadastroDados
    {
        PessoaFisica ObterPorCPF(string cpf);
        PessoaJuridica ObterPorCNPJ(string cnpj);
        void InserirPessoaFisica(PessoaFisica pessoaFisica);
        void InserirPessoaJuridica(PessoaJuridica pessoaJuridica);
    }
}
