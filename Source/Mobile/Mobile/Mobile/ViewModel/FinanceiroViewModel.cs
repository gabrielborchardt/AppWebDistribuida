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
                {
                    Resultado = validacao;
                    return;
                }

                var result = string.Empty;
                var financeiro = Servico.ConsultaApi.BuscarFinanceiro(_Cpf, ref result);

                if (financeiro == null)
                {
                    Resultado = result;
                }
                else
                {
                    if (financeiro.PossuiDividasEmpresa)
                        Resultado = "Possui Dívidas na Empresa";
                    else if (financeiro.PossuiDividasSerasa)
                        Resultado = "Possui Dívidas no Serasa";
                    else
                        Resultado = string.Format("Crédito Liberado: R${0}", financeiro.ValorDisponivel.ToString("N2"));
                }

            }
            catch (Exception ex)
            {
                Resultado = "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}
