using CadastroApp.Dominio.Entidades;
using CadastroApp.Dominio.Entidades.EntidadeBase;
using CadastroApp.Negocio.Interfaces;
using System;
using System.Windows.Forms;

namespace CadastroApp.UI
{
    public partial class Form1 : Form
    {
        private readonly ICadastroNegocio _cadastroNegocio;

        public Form1(ICadastroNegocio cadastroNegocio)
        {
            InitializeComponent();
            _cadastroNegocio = cadastroNegocio;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (PessoaFisicaRadioButton.Checked)
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
            var pessoaFisica = new PessoaFisica
            {
                CEP = CepMaskedTextBox.Text.Replace(" ", "").Replace(".", "").Replace("-", ""),
                Logradouro = LogradouroTextBox.Text,
                Numero = NumeroTextBox.Text,
                Complemento = ComplementoTextBox.Text,
                Bairro = BairroTextBox.Text,
                Cidade = CidadeTextBox.Text,
                UF = UfTextBox.Text.ToUpper(),

                CPF = CpfOrCnpjMaskedTextBox.Text.Replace(" ", "").Replace(",", "").Replace("-", ""),
                DataDeNascimento = DateTime.TryParse(DataNascOrRazaoSocialMaskedTextBox.Text, out date) == true ? date : DateTime.MinValue,
                Nome = NomeOrNomeFantasiaTextBox.Text,
                Sobrenome = SobrenomeTextBox.Text
            };

            if (!ValidaObjetoEMostraErroSeHouver(pessoaFisica))
            {
                return;
            }

            var message = _cadastroNegocio.InserirPessoaFisica(pessoaFisica);

            MessageBox.Show(message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica
            {
                CEP = CepMaskedTextBox.Text.Replace(" ", "").Replace(".", "").Replace("-", ""),
                Logradouro = LogradouroTextBox.Text,
                Numero = NumeroTextBox.Text,
                Complemento = ComplementoTextBox.Text,
                Bairro = BairroTextBox.Text,
                Cidade = CidadeTextBox.Text,
                UF = UfTextBox.Text.ToUpper(),

                CNPJ = CpfOrCnpjMaskedTextBox.Text.Replace(" ", "").Replace(",", "").Replace("/", "").Replace("-", ""),
                RazaoSocial = DataNascOrRazaoSocialMaskedTextBox.Text,
                NomeFantasia = NomeOrNomeFantasiaTextBox.Text
            };

            if (!ValidaObjetoEMostraErroSeHouver(pessoaJuridica))
            {
                return;
            }

            var message = _cadastroNegocio.InserirPessoaJuridica(pessoaJuridica);

            MessageBox.Show(message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidaObjetoEMostraErroSeHouver(Pessoa pessoa)
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
            SobrenomeLlabel.Visible = true;
            SobrenomeTextBox.Visible = true;

            MainGroupBox.Text = "Pessoa Física";

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
            SobrenomeLlabel.Visible = false;
            SobrenomeTextBox.Visible = false;
            SobrenomeTextBox.Text = "";

            MainGroupBox.Text = "Pessoa Jurídica";

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
