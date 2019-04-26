using Desktop.Modelos;
using Desktop.Servicos;
using Desktop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                var usuario = new Usuario()
                {
                    email = txtEmail.Text,
                    senha = txtSenha.Text
                };

                var response = ConsultaApi.Login(usuario);

                if (response == null)
                {
                    lbllResultado.Text = "Erro ao fazer login.";
                }
                else if (response.usuario == null)
                {
                    lbllResultado.Text = response.mensagem;
                }
                else
                {
                    lbllResultado.Text = "";
                    usuario.authenticationKey = response.usuario.authenticationKey;

                    new Home(usuario).Show();

                    Hide();
                }
            }
            catch (Exception ex)
            {
                lbllResultado.Text = ex.Message;
            }
        }
    }
}
