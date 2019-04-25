using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class ConfiguracaoViewModel : INotifyPropertyChanged
    {
        private string _Ip;
        public string Ip
        {
            get { return _Ip; }
            set { _Ip = value; OnPropertyChanged("Ip"); }
        }

        private string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; OnPropertyChanged("Url"); }
        }

        private string _Resultado;
        public string Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; OnPropertyChanged("Resultado"); }
        }

        public Command TestarCommand { get; set; }
        public Command SalvarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ConfiguracaoViewModel()
        {
            TestarCommand = new Command(TestarAction);
            SalvarCommand = new Command(SalvarAction);

            Url = "http://";
        }

        private void TestarAction()
        {
            try
            {
                Resultado = "Conexão: " + Servico.PingServico.PingHost(_Ip);
            }
            catch (Exception ex)
            {
                Resultado = "Ocorreu um erro: " + ex.Message;
            }
        }

        private void SalvarAction()
        {
            if(_Url == null)
            {
                Resultado = "Informe uma URL";
            }

            Util.ConfiguracaoUtil.SetIpConexao(_Url);

            Resultado = "Salvo com sucesso";
        }
    }
}
