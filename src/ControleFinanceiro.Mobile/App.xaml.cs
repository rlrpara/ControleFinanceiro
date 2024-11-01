using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Mobile.Views;

namespace ControleFinanceiro.Mobile
{
    public partial class App : Application
    {
        public App(IBaseRepository baseRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TransacaoLista(baseRepository));
        }
    }
}
