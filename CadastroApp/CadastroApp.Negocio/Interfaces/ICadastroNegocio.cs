using CadastroApp.Dominio.Entidades;

namespace CadastroApp.Negocio.Interfaces
{
    public interface ICadastroNegocio
    {
        string InserirPessoaFisica(PessoaFisica pessoaFisica);
        string InserirPessoaJuridica(PessoaJuridica pessoaJuridica);
    }
}
