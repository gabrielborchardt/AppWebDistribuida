using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbed : TabbedPage
    {
        public HomeTabbed()
        {
            InitializeComponent();

            this.Children.Add(new Frete() { Title = "Frete" });
            this.Children.Add(new Financeiro() { Title = "Financeiro" });
        }
    }
}