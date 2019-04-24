using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public Command FreteCommand { get; set; }
        public Command FinanceiroCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public HomeViewModel()
        {
            FreteCommand = new Command(FreteAction);
            FinanceiroCommand = new Command(FinanceiroAction);
        }

        private void FreteAction()
        {
            try
            {
                App.Current.MainPage = new NavigationPage(new View.Frete());
            }
            catch (Exception ex)
            {
                
            }
        }

        private void FinanceiroAction()
        {
            try
            {
                App.Current.MainPage = new View.Financeiro();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
