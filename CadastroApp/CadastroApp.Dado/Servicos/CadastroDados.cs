using CadastroApp.Dado.Context;
using CadastroApp.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CadastroApp.Dado.Servicos
{
    public class CadastroDados
    {
        private readonly CadastroAppContext _context;

        public CadastroDados()
        {
            _context = new CadastroAppContext();
        }

        public PessoaFisica ObterPorCPF(string cpf)
        {
            return _context.PessoasFisicas.FirstOrDefault(e => e.CPF == cpf);
        }

        public PessoaJuridica ObterPorCNPJ(string cnpj)
        {
            return _context.PessoasJuridicas.FirstOrDefault(e => e.CNPJ == cnpj);
        }

        public void InserirPessoaFisica(PessoaFisica pessoaFisica)
        {
            _context.PessoasFisicas.Add(pessoaFisica);
            _context.SaveChanges();
        }

        public void InserirPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            _context.PessoasJuridicas.Add(pessoaJuridica);
            _context.SaveChanges();
        }
    }
}
