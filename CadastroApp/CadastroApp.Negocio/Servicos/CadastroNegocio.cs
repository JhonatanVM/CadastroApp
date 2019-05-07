using CadastroApp.Dado.Servicos;
using CadastroApp.Dominio.Entidades;
using CadastroApp.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Negocio.Servicos
{
    public class CadastroNegocio
    {
        private readonly CadastroDados _cadastroDados;

        public CadastroNegocio()
        {
            _cadastroDados = new CadastroDados();
        }

        public string InserirPessoaFisica(PessoaFisica pessoaFisica)
        {
            if (_cadastroDados.ObterPorCPF(pessoaFisica.CPF) != null)
            {
                return "Não é possível realizar o cadastro com este CPF!";
            }

            try
            {
                _cadastroDados.InserirPessoaFisica(pessoaFisica);
                return "Inserido com sucesso";
            }
            catch (Exception)
            {
                return "Não foi possível inserir!";
            }
        }

        public string InserirPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            if (_cadastroDados.ObterPorCPF(pessoaJuridica.CNPJ) != null)
            {
                return "Não é possível realizar o cadastro com este CNPJ!";
            }

            try
            {
                _cadastroDados.InserirPessoaJuridica(pessoaJuridica);
                return "Inserido com sucesso";
            }
            catch (Exception)
            {
                return "Não foi possível inserir!";
            }
        }
    }
}
