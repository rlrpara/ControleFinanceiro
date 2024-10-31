using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Service.Interface;
using MinhasFinancas.Service.Service;
using System.Text;

namespace MinhasFinancas.App.Views;

public partial class TransacaoEdit : ContentPage
{
    #region [Private Properties]
    private StringBuilder _mensagem;
    private readonly IBaseRepository _baseRepository;
    private readonly ITransacaoService _transacaoService;
    #endregion

    #region [Constructor]
    public TransacaoEdit(IBaseRepository baseRepository)
    {
        InitializeComponent();

        _baseRepository = baseRepository;
        _transacaoService = new TransacaoService(baseRepository);
    }
    #endregion

    #region [Public methods]
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
    #endregion
}