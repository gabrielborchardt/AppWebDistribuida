using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class FreteViewModel : INotifyPropertyChanged
    {
        private string _Cep;
        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; OnPropertyChanged("Cep"); }
        }

        private decimal _Peso;
        public decimal Peso
        {
            get { return _Peso; }
            set { _Peso = value; OnPropertyChanged("Peso"); }
        }

        private decimal _Tamanho;
        public decimal Tamanho
        {
            get { return _Tamanho; }
            set { _Tamanho = value; OnPropertyChanged("Tamanho"); }
        }

        private string _Resultado;
        public string Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; OnPropertyChanged("Resultado"); }
        }

        public Command CalcularCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public FreteViewModel()
        {
            Resultado = "Informe os dados.";
            CalcularCommand = new Command(CalcularAction);
        }

        private void CalcularAction()
        {
            try
            {
                var validacao = string.Empty;

                validacao = Helpers.CepHelper.IsValid(_Cep);
                if (validacao != "OK")
                {
                    Resultado = validacao;
                    return;
                }

                if (_Peso == 0)
                {
                    Resultado = "Digite o peso da embalagem.";
                    return;
                }

                if (_Tamanho == 0)
                {
                    Resultado = "Digite o tamanho da embalagem.";
                    return;
                }

                var result = string.Empty;
                var frete = Servico.ConsultaApi.BuscarFrete(_Cep, _Peso, _Tamanho, ref result);

                if(frete == null)
                {
                    Resultado = result;
                }
                else
                {
                    Resultado = string.Format("Local: {0} - {1}/{2}" + 
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
                Resultado = "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}
