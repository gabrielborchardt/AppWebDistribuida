using Desktop.Modelos;
using Desktop.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.View
{
    public partial class Home : Form
    {

        private readonly Usuario _usuario;
        public Home(Usuario usuario)
        {
            InitializeComponent();

            _usuario = usuario;
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTamanho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TxtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cep = txtCep.Text;

                decimal.TryParse(txtPeso.Text, out var peso);

                decimal.TryParse(txtTamanho.Text, out var tamanho);

                var validacao = string.Empty;

                validacao = Helpers.CepHelper.IsValid(cep);
                if (validacao != "OK")
                {
                    lblResultadoFrete.Text = validacao;
                    return;
                }

                if (peso == 0)
                {
                    lblResultadoFrete.Text = "Digite o peso da embalagem.";
                    return;
                }

                if (tamanho == 0)
                {
                    lblResultadoFrete.Text = "Digite o tamanho da embalagem.";
                    return;
                }

                var result = string.Empty;
                var frete = ConsultaApi.BuscarFrete(_usuario, cep, peso, tamanho, ref result);

                if (frete == null)
                {
                    lblResultadoFrete.Text = result;
                }
                else
                {
                    lblResultadoFrete.Text = string.Format("Local: {0} - {1}/{2}" +
                                                Environment.NewLine +
                                                "Valor: R${3}",
                                                frete.Rua,
                                                frete.Cidade,
                                                frete.Estado,
                                                frete.Valor.ToString("N2"));
                }
            }
            catch (Exception ex)
            {
                lblResultadoFrete.Text = "Ocorreu um erro: " + ex.Message;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var cpf = txtCpf.Text;
                var validacao = string.Empty;

                validacao = Helpers.CpfHelper.IsValid(cpf);
                if (validacao != "OK")
                {
                    lblResultadoFinanceiro.Text = validacao;
                    return;
                }

                var result = string.Empty;
                var financeiro = ConsultaApi.BuscarFinanceiro(_usuario, cpf, ref result);

                if (financeiro == null)
                {
                    lblResultadoFinanceiro.Text = result;
                }
                else
                {
                    if (financeiro.PossuiDividasEmpresa)
                        lblResultadoFinanceiro.Text = "Possui Dívidas na Empresa";
                    else if (financeiro.PossuiDividasSerasa)
                        lblResultadoFinanceiro.Text = "Possui Dívidas no Serasa";
                    else
                        lblResultadoFinanceiro.Text = string.Format("Crédito Liberado: R${0}", financeiro.ValorDisponivel.ToString("N2"));
                }

            }
            catch (Exception ex)
            {
                lblResultadoFinanceiro.Text = "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}
