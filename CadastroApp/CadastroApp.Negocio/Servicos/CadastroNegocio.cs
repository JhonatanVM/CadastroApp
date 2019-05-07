using CadastroApp.Dado.Interfaces;
using CadastroApp.Dado.Servicos;
using CadastroApp.Dominio.Entidades;
using CadastroApp.Negocio.Interfaces;
using System;

namespace CadastroApp.Negocio.Servicos
{
    public class CadastroNegocio : ICadastroNegocio
    {
        private readonly ICadastroDados _cadastroDados;

        public CadastroNegocio(ICadastroDados cadastroDados)
        {
            _cadastroDados = cadastroDados;
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
            if (_cadastroDados.ObterPorCNPJ(pessoaJuridica.CNPJ) != null)
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
