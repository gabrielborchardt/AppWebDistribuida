using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class FreteViewModel : INotifyPropertyChanged
    {
        private string _CepOrigem;
        public string CepOrigem
        {
            get { return _CepOrigem; }
            set { _CepOrigem = value; OnPropertyChanged("CepOrigem"); }
        }

        private string _CepDestino;
        public string CepDestino
        {
            get { return _CepDestino; }
            set { _CepDestino = value; OnPropertyChanged("CepDestino"); }
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
            CalcularCommand = new Command(CalcularAction);
        }

        private void CalcularAction()
        {
            try
            {
                var validacao = string.Empty;

                validacao = Helpers.CepHelper.IsValid(_CepOrigem);
                if (validacao != "OK")
                    _Resultado = validacao;

                validacao = Helpers.CepHelper.IsValid(_CepDestino);
                if (validacao != "OK")
                    _Resultado = validacao;

                if (_Peso == 0)
                    _Resultado = "Digite o peso da embalagem.";

                if (_Tamanho == 0)
                    _Resultado = "Digite o tamanho da embalagem.";

                var frete = Servico.ConsultaApi.BuscarFrete(_CepOrigem, _CepOrigem, _Peso, _Tamanho);

                if(frete == null)
                {
                    _Resultado = "Não foi possivel calcular o frete.";
                }
                else
                {
                    _Resultado = string.Format("Local:{0},{1},{2}" + 
                                                Environment.NewLine +
                                                "Valor: R${3}", 
                                                frete.Rua, 
                                                frete.Cidade,
                                                frete.Estado,
                                                frete.Valor);
                }

            }
            catch (Exception ex)
            {
                _Resultado = "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}
