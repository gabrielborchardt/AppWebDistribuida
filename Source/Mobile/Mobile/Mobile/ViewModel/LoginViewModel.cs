using System;
using System.ComponentModel;
using Xamarin.Forms;
using Mobile.Servico;
using Mobile.Util;
using Mobile.Model;

namespace Mobile.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool _carregando;
        public bool Carregando
        {
            get { return _carregando; }
            set { _carregando = value; OnPropertyChanged("Carregando"); }
        }

        private bool _msgErro;
        public bool MsgErro
        {
            get { return _msgErro; }
            set { _msgErro = value; OnPropertyChanged("MsgErro"); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged("Email"); }
        }

        private string _Senha;
        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; OnPropertyChanged("Senha"); }
        }

        private string _Mensagem;
        public string Mensagem
        {
            get { return _Mensagem; }
            set { _Mensagem = value; OnPropertyChanged("Mensagem"); }
        }

        public Command EntrarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public LoginViewModel()
        {
            EntrarCommand = new Command(EntrarAction);
        }

        private async void EntrarAction()
        {
            try
            {
                Carregando = true;
                _msgErro = false;

                var usuario = new Usuario()
                {
                    email = Email,
                    senha = Senha
                };

                var response = await ConsultaApi.Login(usuario);
                if (response == null)
                {
                    Mensagem = "Erro ao fazer login.";
                    MsgErro = true;
                    Carregando = false;
                }
                else if(response.usuario == null)
                {
                    Mensagem = response.mensagem;
                    MsgErro = true;
                    Carregando = false;
                }
                else
                {
                    Mensagem = "";
                    MsgErro = false;
                    Carregando = false;

                    UsuarioUtil.SetUsuarioLogado(response.usuario);
                    App.Current.MainPage = new View.Home();
                }
            }
            catch (Exception ex)
            {
                Mensagem = ex.Message;
                MsgErro = true;
            }
            finally
            {
                Carregando = false;
            }
        }
    }
}
