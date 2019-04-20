using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class FinanceiroViewModel : INotifyPropertyChanged
    {
        private string _Cpf;
        public string Cpf
        {
            get { return _Cpf; }
            set { _Cpf = value; OnPropertyChanged("Cpf"); }
        }

        private string _Resultado;
        public string Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; OnPropertyChanged("Resultado"); }
        }

        public Command VerificarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public FinanceiroViewModel()
        {
            VerificarCommand = new Command(VerificarAction);
        }

        private void VerificarAction()
        {
            try
            {
                var validacao = string.Empty;

                validacao = Helpers.CpfHelper.IsValid(_Cpf);
                if (validacao != "OK")
                    _Resultado = validacao;

                var financeiro = Servico.ConsultaApi.BuscarFinanceiro(_Cpf);

                if (financeiro == null)
                {
                    _Resultado = "Não foi possivel verificar a situação financeira.";
                }
                else
                {
                    if (financeiro.bloqueado)
                        _Resultado = "CPF Bloqueado";
                    else
                        _Resultado = string.Format("Valor Liberado: R${0}", financeiro.valor);
                }

            }
            catch (Exception ex)
            {
                _Resultado = "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}
