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

                CPF = CpfOrCnpjMaskedTextBox.Text.Replace(" ", "").Replace(",", "").Replace("-", ""),
                DataDeNascimento = DateTime.TryParse(DataNascOrRazaoSocialMaskedTextBox.Text, out date) == true ? date : DateTime.MinValue,
                Nome = NomeOrNomeFantasiaTextBox.Text,
                Sobrenome = SobrenomeTextBox.Text
            };

            if (!ValidateObjectAndShowMessageIfError(pessoaFisica))
            {
                return;
            }

            var message = _cadastroNegocio.InserirPessoaFisica(pessoaFisica);

            MessageBox.Show(message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                CNPJ = CpfOrCnpjMaskedTextBox.Text.Replace(" ", "").Replace(",", "").Replace("/", "").Replace("-", ""),
                RazaoSocial = DataNascOrRazaoSocialMaskedTextBox.Text,
                NomeFantasia = NomeOrNomeFantasiaTextBox.Text
            };

            if (!ValidateObjectAndShowMessageIfError(pessoaJuridica))
            {
                return;
            }

            var message = _cadastroNegocio.InserirPessoaJuridica(pessoaJuridica);

            MessageBox.Show(message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateObjectAndShowMessageIfError(Pessoa pessoa)
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

        private void PessoaFisicaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Checked = 1;

            SobrenomeLlabel.Visible = true;
            SobrenomeTextBox.Visible = true;

            CpfOrCnpjLabel.Text = "CPF";
            CpfOrCnpjMaskedTextBox.Mask = "999.999.999-99";
            CpfOrCnpjMaskedTextBox.Text = "";

            DataNascOrRazaoSociaLabel.Text = "Data de Nascimento";
            DataNascOrRazaoSocialMaskedTextBox.Mask = "99/99/9999";
            DataNascOrRazaoSocialMaskedTextBox.Text = "";

            NomeOrNomeFantasiaLabel.Text = "Nome";
            NomeOrNomeFantasiaTextBox.Text = "";
        }

        private void PessoaJuridicaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Checked = 2;

            SobrenomeLlabel.Visible = false;
            SobrenomeTextBox.Visible = false;
            SobrenomeTextBox.Text = "";

            CpfOrCnpjLabel.Text = "CNPJ";
            CpfOrCnpjMaskedTextBox.Mask = "99.999.999/9999-99";
            CpfOrCnpjMaskedTextBox.Text = "";

            DataNascOrRazaoSociaLabel.Text = "Razão Social";
            DataNascOrRazaoSocialMaskedTextBox.Mask = "";
            DataNascOrRazaoSocialMaskedTextBox.Text = "";

            NomeOrNomeFantasiaLabel.Text = "Nome Fantasia";
            NomeOrNomeFantasiaTextBox.Text = "";
        }
    }
}
