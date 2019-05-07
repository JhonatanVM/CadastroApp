using CadastroApp.Dominio.Entidades;
using CadastroApp.Dominio.Entidades.EntidadeBase;
using CadastroApp.Negocio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroApp.UI
{
    public partial class Form1 : Form
    {
        private readonly CadastroNegocio _cadastroNegocio;
        private PessoaFisica pessoaFisica;
        private PessoaJuridica pessoaJuridica;
        private int Checked = 1;

        public Form1()
        {
            InitializeComponent();
            _cadastroNegocio = new CadastroNegocio();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (Checked == 1)
            {
                InserirPessoaFisica();
            }
            else
            {
                InserirPessoaJuridica();
            }
        }

        private void InserirPessoaFisica()
        {
            DateTime date;
            pessoaFisica = new PessoaFisica
            {
                CEP = CEPMaskedTextBox.Text.Replace(" ", "").Replace(".", "").Replace("-", ""),
                Logradouro = LogradouroTextBox.Text,
                Numero = NumeroTextBox.Text,
                Complemento = ComplementoTextBox.Text,
                Bairro = BairroTextBox.Text,
                Cidade = CidadeTextBox.Text,
                UF = UFTextBox.Text,

                CPF = CPFMaskedTextBox.Text.Replace(" ", "").Replace(",", "").Replace("-", ""),
                DataDeNascimento = DateTime.TryParse(DataNascimentoMaskedTextBox.Text, out date) == true ? date : DateTime.MinValue,
                Nome = NomeTextBox.Text,
                Sobrenome = SobrenomeTextBox.Text
            };

            if (!ShowValidationResult(pessoaFisica))
            {
                return;
            }

            var message = _cadastroNegocio.InserirPessoaFisica(pessoaFisica);

            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirPessoaJuridica()
        {
            pessoaJuridica = new PessoaJuridica
            {
                CEP = CEPMaskedTextBox.Text.Replace(" ", "").Replace(".", "").Replace("-", ""),
                Logradouro = LogradouroTextBox.Text,
                Numero = NumeroTextBox.Text,
                Complemento = ComplementoTextBox.Text,
                Bairro = BairroTextBox.Text,
                Cidade = CidadeTextBox.Text,
                UF = UFTextBox.Text,

                CNPJ = CNPJTextBox.Text.Replace(" ", "").Replace(",", "").Replace("/", "").Replace("-", ""),
                RazaoSocial = RazaoSocialTextBox.Text,
                NomeFantasia = NomeFantasiaTextBox.Text
            };

            if (!ShowValidationResult(pessoaJuridica))
            {
                return;
            }

            var message = _cadastroNegocio.InserirPessoaJuridica(pessoaJuridica);

            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ShowValidationResult(Pessoa pessoa)
        {
            var result = pessoa.Validate();
            if (!result.IsValid)
            {
                string errorMessage = "";
                foreach (var error in result.Errors)
                {
                    errorMessage += $"   - {error.ErrorMessage}\n";
                }
                MessageBox.Show($"Formulário preenchido incorretamente:\n\n{errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Checked = 1;
            PainelPadrao.Visible = true;
            PainelPessoaFisica.Visible = true;
            PainelPessoaJuridica.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Checked = 2;
            PainelPadrao.Visible = true;
            PainelPessoaFisica.Visible = false;
            PainelPessoaJuridica.Visible = true;
        }
    }
}
