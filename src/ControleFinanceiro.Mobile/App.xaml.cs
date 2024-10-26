using ControleFinanceiro.Mobile.Views;

namespace ControleFinanceiro.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TransacaoLista());
        }
    }
}
